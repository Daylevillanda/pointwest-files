const db = require('../config/db');

const reimbursementSQL = `
SELECT r.*, e.*,c.*
FROM (SELECT * FROM flexben.flex_reimbursement ORDER BY status = "Submitted" DESC) as r
INNER JOIN flexben.employee as e
ON r.employee_id = e.employee_id
INNER JOIN (SELECT * FROM flexben.flex_cycle_cutoff WHERE is_active = "y") as c
ON r.flex_cutoff_id = c.flex_cutoff_id
`
const reimbursementByIdSQL = reimbursementSQL + `HAVING r.flex_reimbursement_id = ?`
let itemsSQL = `
    SELECT *
    FROM flexben.flex_reimbursement_details
    WHERE flex_reimbursement_id = ?;
`

exports.getAll = async () => {
    const reimbursements = await db.execute(reimbursementSQL)
    return reimbursements
}

exports.getById = async (id) => {
    const reimbursement = await db.execute(reimbursementByIdSQL, [id])
    return reimbursement
}

exports.getItems = async (id) => {
    const items = await db.execute(itemsSQL, [id])
    return items
}

exports.getFilter = async ({emp_num, last_name, first_name}) => {
    let employee_number = emp_num? `LIKE "${emp_num}%"` :"> 0"
    let lastname = last_name? `LIKE "%${last_name}%"` :"IS NOT NULL"
    let firstname = first_name? `LIKE "%${first_name}%"` :"IS NOT NULL"
    let reimbursementFilterSQL = reimbursementSQL + `HAVING e.employee_number ${employee_number} AND e.lastname ${lastname} AND e.firstname ${firstname}`
    const reimbursements = await db.execute(reimbursementFilterSQL)
    return reimbursements
}