const db = require('../db/connect');
const moment = require('moment');
const { createWriteStream } = require('fs');
const { generateToken, getIdFromToken } = require("../services/jwt");

const generateReimbursement = async (req, res) => {
    let token = req.cookies.token
    let id = getIdFromToken(token)
    const new_token = await generateToken(token, null)
    res.cookie("token", new_token, { httpOnly: true });

    let activeReimbursementSQL = `
        SELECT r.*, e.*
        FROM flexben.flex_reimbursement as r
        INNER JOIN (SELECT * FROM flexben.flex_cycle_cutoff WHERE is_active = "y") as c
        ON r.flex_cutoff_id = c.flex_cutoff_id
        INNER JOIN flexben.employee as e
        ON r.employee_id = e.employee_id
        HAVING r.employee_id = ?
    `
    let activeItemsSQL = `
        SELECT * 
        FROM flexben.flex_reimbursement_details 
        WHERE flex_reimbursement_id = ?
    `

    const reimbursement = await db.execute(activeReimbursementSQL,[Number(id)]);
    const [items] = await db.execute(activeItemsSQL,[reimbursement[0][0]?.flex_reimbursement_id]);
    const [category] = await db.execute('SELECT * FROM flexben.categories');
    let result = reimbursement[0][0]
    let filename = `reimbursement_${(result.lastname).toLowerCase()}_${result.firstname.toLowerCase()}_${result.transaction_number}`
    const writer = createWriteStream(`./generated-file/${filename}.txt`)

writer.write(`Employee Name: ${result.lastname}, ${result.firstname}
Employee Number: ${result.employee_number}
Date Submitted: ${moment(result.date_submitted).format('MMMM DD, YYYY')}
Transaction Number: ${result.transaction_number}
Amount:	Php ${result.total_reimbursement_amount}
Status: ${result.status}

=== DETAILS ===
`)
    for (let c of category){
        writer.write(`\nCATEGORY: ${c.name}`)
        writer.write('\n')
        let counter = 1
        let details = items.filter(o => o.category_id === c.category_id)
        if(details[0]){
            for (let i of details){
                if(c.category_id == i.category_id){
                    writer.write(`Item # ${counter}\n`)
writer.write(`Date: ${moment(i.date_added).format('MMMM DD, YYYY')}
OR Number: ${i.or_number}
Name of Establishment: ${i.name_of_establishment}
TIN of Establishment: ${i.tin_of_establishment}
Amount: Php ${i.amount}
Status: ${i.status}

`)
                }
                counter++
            }
        }
        else writer.write(`N/A\n`)
    }

    res.status(200).json({ 
        "status": 200,
        "statusText": "OK",
        "message": filename,
        "reimbursement": reimbursement[0][0],
        "items": items
    });
}

module.exports = {
    generateReimbursement
};