const db = require('../db/connect');
const moment = require('moment');
const { generateToken } = require("../services/jwt");

let reimbursementSQL = `
    SELECT r.*, e.*,c.*
    FROM flexben.flex_reimbursement as r
    INNER JOIN flexben.employee as e
    ON r.employee_id = e.employee_id
    INNER JOIN flexben.flex_cycle_cutoff as c
    ON r.flex_cutoff_id = c.flex_cutoff_id
    HAVING c.is_active = "y"
    ORDER BY r.status = "Submitted" DESC;
`
let itemsSQL = `
    SELECT *
    FROM flexben.flex_reimbursement_details
    WHERE flex_reimbursement_id = ?;
`
const getReimbursement = async () => {
    const [rows] = await db.execute(reimbursementSQL);
    let result = rows.map(
        (o) => ({ 
            flex_reimbursement_id: o.flex_reimbursement_id,
            transaction_number: o.transaction_number,
            employee_number: o.employee_number,
            total_reimbursement_amount: o.total_reimbursement_amount,
            employee_name: o.lastname+", "+o.firstname,
            date_submitted: o.date_submitted,
            status: o.status
        }))
    return result
}
const getItems = async (id) => {
    const [rows] = await db.execute(itemsSQL,[id]);
    items = rows.map((o) => ({ 
        flex_reimbursement_detail_id: o.flex_reimbursement_detail_id,
        date_added: o.date_added,
        or_number: o.or_number,
        name_of_establishment: o.name_of_establishment,
        tin_of_establishment: o.tin_of_establishment,
        amount: o.amount,
        category_id: o.category_id
    }))
    return items
}
const updateReimbursement = async (id, status) => {
    const updateReimbursement = await db.execute('UPDATE flex_reimbursement SET status = ? WHERE flex_reimbursement_id = ?',[status, id]);
    const updateItems = await db.execute('UPDATE flex_reimbursement_details SET status = ? WHERE flex_reimbursement_id = ?',[status, id]);
}

const getAll = async (req, res) => {
    let token = req.cookies.token
    const new_token = await generateToken(token, null)
    res.cookie("token", new_token, { httpOnly: true });

    let result = await getReimbursement()
    res.status(200).json({ 
        "status": 200,
        "statusText": "OK",
        "message": result[0]? "Reimbursements retrieved" : "No reimbursement found",
        "data": result
    });
};

const getSearch = async (req, res) => {
    const { emp_num, last_name, first_name} = req.query;
    let token = req.cookies.token
    const new_token = await generateToken(token, null)
    res.cookie("token", new_token, { httpOnly: true });

    if(emp_num || last_name || first_name){
        const [rows] = await db.execute(reimbursementSQL);
        let result = [...rows]

        if(emp_num){
            result = result.filter(({employee_number}) => employee_number == emp_num)
        }
        if(last_name){
            result = result.filter(({lastname}) => (String(lastname.toLowerCase()).includes(last_name.toLowerCase())))
        }
        if(first_name){
            result = result.filter(({firstname}) => (String(firstname.toLowerCase()).includes(first_name.toLowerCase())))
        }
        
        result = await Promise.all(result.map(
            async (o) => ({ 
                flex_reimbursement_id: o.flex_reimbursement_id,
                transaction_number: o.transaction_number,
                employee_number: o.employee_number,
                total_reimbursement_amount: o.total_reimbursement_amount,
                employee_name: o.lastname+", "+o.firstname,
                date_submitted: o.date_submitted,
                status: o.status,
                items: (await db.execute(itemsSQL,[o.flex_reimbursement_id]))[0]
            }))
        )

        return res.status(200).json({ 
            "status": 200,
            "statusText": "OK",
            "message": result[0]? "Reimbursements retrieved" : "No reimbursement found",
            "data": result
        });
    }
    res.status(200).json({ 
        "status": 200,
        "statusText": "OK",
        "message": "Use 'emp_num', 'last_name', or 'first_name' to filter",
    });
};

const getById = async (req, res) => {
    const { id } = req.params
    let token = req.cookies.token
    const new_token = await generateToken(token, null)
    res.cookie("token", new_token, { httpOnly: true });

    let result = await getReimbursement()
    result = result.filter(({flex_reimbursement_id}) => Number(flex_reimbursement_id) === Number(id))
    let items = []
    if(result[0]){
        items = await getItems(id)
    }
    res.status(200).json({ 
        "status": 200,
        "statusText": "OK",
        "message": result[0]? "Reimbursements retrieved" : "No reimbursement found",
        "data": {reimbursement:result,items:items}
    });
};

const update = async (req, res) => {
    const { id } = req.params
    const obj = req.body
    let token = req.cookies.token
    const new_token = await generateToken(token, null)
    res.cookie("token", new_token, { httpOnly: true });

    if(obj.action === "Approve")
        await updateReimbursement(id, "Approved")
    if(obj.action === "Reject")
        await updateReimbursement(id, "Rejected")

    res.status(200).json({ 
        "status": 200,
        "statusText": "OK",
        "message": "success"
    });
};

module.exports = {
    getAll,
    getById,
    getSearch,
    update
};