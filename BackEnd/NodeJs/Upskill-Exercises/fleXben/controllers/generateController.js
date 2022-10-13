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
    const [rows] = await db.execute(activeItemsSQL,[reimbursement[0][0]?.flex_reimbursement_id]);
    let result = reimbursement[0][0]
    let filename = `reimbursement_${(result.lastname).toLowerCase()}_${result.firstname.toLowerCase()}_${result.transaction_number}`
    const writer = createWriteStream(`./generated-file/${filename}.txt`)

    writer.write(`
    Employee Name: ${result.lastname}, ${result.firstname}
    Employee Number: ${result.employee_number}
    Date Submitted: ${moment(result.date_submitted).format('MMMM DD, YYYY')}
    Transaction Number: ${result.transaction_number}
    Amount:	Php ${result.total_reimbursement_amount}
    Status: ${result.status}

    === DETAILS ===

    `)

    res.status(200).json({ 
        "status": 200,
        "statusText": "OK",
        "message": filename,
        "reimbursement": reimbursement[0][0],
        "items": rows
    });
}

module.exports = {
    generateReimbursement
};