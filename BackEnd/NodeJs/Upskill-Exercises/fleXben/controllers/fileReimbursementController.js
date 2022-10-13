const db = require('../db/connect');
const moment = require('moment');
const { generateToken, getIdFromToken } = require("../services/jwt");
const { minimumAmount } = require("../config/reimbursementConfig");

let activeFlexCutoffSQL = `
SELECT * 
FROM flexben.flex_cycle_cutoff 
WHERE is_active = "y"
`

let activeReimbursementSQL = `
    SELECT r.*
    FROM flexben.flex_reimbursement as r
    INNER JOIN (SELECT * FROM flexben.flex_cycle_cutoff WHERE is_active = "y") as c
    ON r.flex_cutoff_id = c.flex_cutoff_id
    HAVING r.employee_id = ?
`

const getActiveReimbursement = async (req, res) => {
    let token = req.cookies.token
    let id = getIdFromToken(token)
    let reimbursementItems = []
    const new_token = await generateToken(token, null)
    res.cookie("token", new_token, { httpOnly: true });
    
    const [rows] = await db.execute(activeReimbursementSQL,[Number(id)]);
    if(rows[0])
        reimbursementItems = await db.execute(`SELECT * FROM flexben.flex_reimbursement_details WHERE flex_reimbursement_id = ${rows[0]?.flex_reimbursement_id}`)
    res.status(200).json({ 
        "status": 200,
        "statusText": "OK",
        "message": rows[0]? "Reimbursement retrieved" : "No reimbursement found",
        "data": {
            reimbursement: rows[0],
            items: reimbursementItems[0]
        },
    });
};

const addReimbursement = async (req, res) => {
    const reimbursement = req.body
    
    let token = req.cookies.token
    let id = getIdFromToken(token)
    const new_token = await generateToken(token, null)
    res.cookie("token", new_token, { httpOnly: true });

    const activeFlexCutoff = await db.execute(activeFlexCutoffSQL);
    if(!activeFlexCutoff[0][0]){
        return res.status(400).json({ 
            "status": 400,
            "statusText": "BAD REQUEST",
            "message": "No Active Flex Cutoff found",
        });
    }

    if(reimbursement){
        if(reimbursement.amount < minimumAmount){
            return res.status(400).json({ 
                "status": 400,
                "statusText": "BAD REQUEST",
                "message": `Minimum Amount per request is PHP ${minimumAmount}`,
            });
        }
        if(reimbursement.amount > activeFlexCutoff[0][0]?.cut_off_cap_amount){
            return res.status(400).json({ 
                "status": 400,
                "statusText": "BAD REQUEST",
                "message": `Maximum Amount per request is PHP ${activeFlexCutoff[0][0]?.cut_off_cap_amount}`,
            });
        }
        let dateNow = new Date(Date.now())
        let dateGiven = new Date(reimbursement.date) 
        let cutoffStartDate = new Date(activeFlexCutoff[0][0].start_date) 
        let cutoffEndDate = new Date(activeFlexCutoff[0][0].end_date) 
        if(dateGiven > dateNow){
            return res.status(400).json({ 
                "status": 400,
                "statusText": "BAD REQUEST",
                "message": `The date is greater than the date today`,
            });
        }
        if(dateGiven.getFullYear() != dateNow.getFullYear()){
            return res.status(400).json({ 
                "status": 400,
                "statusText": "BAD REQUEST",
                "message": `Invalid Year`,
            });
        }
        if(dateGiven < cutoffStartDate || dateGiven > cutoffEndDate) {
            return res.status(400).json({ 
                "status": 400,
                "statusText": "BAD REQUEST",
                "message": `Date given is not within the cutoff date`,
            });
        }
    }

    const activeReimbursement = await db.execute(activeReimbursementSQL,[Number(id)]);
    let reimbursementHead = 0
    
    if(!activeReimbursement[0][0]){
        let createReimbursement = `
            INSERT INTO flexben.flex_reimbursement (employee_id, flex_cutoff_id, total_reimbursement_amount)
            VALUES (?,?,?)
        `
        const [rows, results, fields] = await db.query(createReimbursement,[id,activeFlexCutoff[0][0].flex_cutoff_id,reimbursement.amount]);
        reimbursementHead = rows.insertId
    }
    else{
        if(activeReimbursement[0][0]?.status === "Submitted" || activeReimbursement[0][0]?.status === "Approved"){
            return res.status(400).json({ 
                "status": 400,
                "statusText": "BAD REQUEST",
                "message": `Changes are not allowed`,
            });
        }
        reimbursementHead = activeReimbursement[0][0]?.flex_reimbursement_id
        let updateReimbursement = `
            UPDATE flexben.flex_reimbursement 
            SET total_reimbursement_amount = total_reimbursement_amount + ${reimbursement.amount}
            WHERE flex_reimbursement_id = ${reimbursementHead}
        `
        const [rows, results, fields] = await db.query(updateReimbursement);
    }

    let createItem = `
        INSERT INTO flexben.flex_reimbursement_details (flex_reimbursement_id, or_number, name_of_establishment, tin_of_establishment, amount, category_id, date_added)
        VALUES (?,?,?,?,?,?,?)
    `
    const [rows, results, fields] = await db.query(createItem,
        [
            reimbursementHead,
            reimbursement.or,
            reimbursement.establishment,
            reimbursement.tin_establishment,
            reimbursement.amount,
            reimbursement.category,
            (new Date(reimbursement.date))
        ]
    );
    
    const reimbursementList = await db.execute(`SELECT * FROM flexben.flex_reimbursement WHERE flex_reimbursement_id = ${reimbursementHead}`)
    const reimbursementItems = await db.execute(`SELECT * FROM flexben.flex_reimbursement_details WHERE flex_reimbursement_id = ${reimbursementHead}`)
    res.status(200).json({ 
        "status": 200,
        "statusText": "OK",
        "message": "Reimbursement successfully added",
        "data": {
            reimbursement: reimbursementList[0][0],
            items: reimbursementItems[0]
        },
    });
};

const removeReimbursement = async (req, res) => {
    const { id } = req.params
    let token = req.cookies.token
    let empId = getIdFromToken(token)
    const new_token = await generateToken(token, null)
    res.cookie("token", new_token, { httpOnly: true });

    let sql = `
        SELECT r.*, d.*
        FROM flexben.flex_reimbursement as r
        INNER JOIN flexben.flex_reimbursement_details as d
        ON r.flex_reimbursement_id = d.flex_reimbursement_id
        HAVING r.employee_id = ? AND d.flex_reimbursement_detail_id = ?;
    `

    const validate = await db.execute(sql, [empId, id])
    if(validate[0][0]){
        if(validate[0][0]?.status === "Submitted" || validate[0][0]?.status === "Approved"){
            return res.status(400).json({ 
                "status": 400,
                "statusText": "BAD REQUEST",
                "message": `Changes are not allowed`,
            });
        }
        const deleteItem = await db.query('DELETE FROM `flex_reimbursement_details` WHERE flex_reimbursement_detail_id = ?', [validate[0][0]?.flex_reimbursement_detail_id]);
        const updateReimbursement = await db.query(
            `
            UPDATE flex_reimbursement 
            SET total_reimbursement_amount = total_reimbursement_amount - ${validate[0][0]?.amount} 
            WHERE flex_reimbursement_id = ${validate[0][0]?.flex_reimbursement_id}
        `);
        
        return res.status(200).json({ 
            "status": 200,
            "statusText": "OK",
            "message": "Reimbursement item successfully deleted",
        });
    }
    
    res.status(400).json({ 
        "status": 400,
        "statusText": "BAD REQUEST",
        "message": "Invalid Request",
    });
}

const updateReimbursement = async (req, res) => {
    const action = req.body
    let token = req.cookies.token
    let empId = getIdFromToken(token)
    const new_token = await generateToken(token, null)
    res.cookie("token", new_token, { httpOnly: true });

    let sql = `
        SELECT r.*, c.*
        FROM flexben.flex_reimbursement as r
        INNER JOIN (SELECT * FROM flexben.flex_cycle_cutoff WHERE is_active = "y") as c
        ON r.flex_cutoff_id = c.flex_cutoff_id
        HAVING r.employee_id = ?
    `

    const validate = await db.execute(sql, [empId])
    if(validate[0][0] && action.submit === true){
        if(validate[0][0]?.status === "Submitted" || validate[0][0]?.status === "Approved"){
            return res.status(400).json({ 
                "status": 400,
                "statusText": "BAD REQUEST",
                "message": `Changes are not allowed`,
            });
        }
        if(validate[0][0]?.total_reimbursement_amount > validate[0][0]?.cut_off_cap_amount){
            return res.status(400).json({ 
                "status": 400,
                "statusText": "BAD REQUEST",
                "message": `Total reimbursement amount is greater than the cutoff cap amount`,
            });
        }

        let getCompanycodeSQL = `
            SELECT e.employee_id, c.code 
            FROM flexben.employee as e
            INNER JOIN flexben.company as c
            ON e.company_id = c.company_id
            HAVING e.employee_id = ?
        `
        const getCompanycode = await db.execute(getCompanycodeSQL, [empId])
        let transactionNumber = getCompanycode[0][0]?.code+'-'+validate[0][0]?.flex_cutoff_id+'-'+moment(Date.now()).format('YYYYMMDD')+'-'+validate[0][0]?.flex_reimbursement_id
        const updateReimbursement = await db.query(
            `
            UPDATE flex_reimbursement 
            SET transaction_number = "${transactionNumber}", status = "Submitted", date_submitted = CURRENT_DATE()
            WHERE flex_reimbursement_id = ${validate[0][0]?.flex_reimbursement_id}
        `);
        const updateReimbursementItems = await db.query(
            `
            UPDATE flex_reimbursement_details 
            SET status = "Submitted"
            WHERE flex_reimbursement_id = ${validate[0][0]?.flex_reimbursement_id}
        `);
        
        return res.status(200).json({ 
            "status": 200,
            "statusText": "OK",
            "message": "Reimbursement item successfully submitted",
        });
    }
    
    res.status(400).json({ 
        "status": 400,
        "statusText": "BAD REQUEST",
        "message": "Invalid Request",
    });

}

module.exports = {
    getActiveReimbursement,
    addReimbursement,
    removeReimbursement,
    updateReimbursement
};