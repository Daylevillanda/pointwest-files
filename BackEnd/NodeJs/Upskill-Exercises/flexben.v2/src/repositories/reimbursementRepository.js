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
const itemsSQL = `
    SELECT *
    FROM flexben.flex_reimbursement_details
    WHERE flex_reimbursement_id = ?;
`
const updateReimbursement = async (id, status) => {
    status = status[0].toUpperCase() + status.slice(1)
    let updateReimbursementSQL = `UPDATE flex_reimbursement SET status = ? WHERE flex_reimbursement_id = ?`
    let updateItemsSQL = `UPDATE flex_reimbursement_details SET status = ? WHERE flex_reimbursement_id = ?`
    const reimbursement = await db.execute(updateReimbursementSQL, [status, id]);
    const items = await db.execute(updateItemsSQL, [status, id]);
    return [{reimbursement:reimbursement[0].info, items:items[0].info}]
}

exports.getAll = async () => {
    return await db.execute(reimbursementSQL)
}

exports.getById = async (id) => {
    return await db.execute(reimbursementByIdSQL, [id])
}

exports.getItems = async (id) => {
    return await db.execute(itemsSQL, [id])
}

exports.getFilter = async ({emp_num, last_name, first_name}) => {
    let employee_number = emp_num? `LIKE "${emp_num}%"` :"> 0"
    let lastname = last_name? `LIKE "%${last_name}%"` :"IS NOT NULL"
    let firstname = first_name? `LIKE "%${first_name}%"` :"IS NOT NULL"
    let reimbursementFilterSQL = reimbursementSQL + `HAVING e.employee_number ${employee_number} AND e.lastname ${lastname} AND e.firstname ${firstname}`
    return await db.execute(reimbursementFilterSQL)
}

exports.updateById = async (id,status) => {
    return await updateReimbursement(id,status)
}
