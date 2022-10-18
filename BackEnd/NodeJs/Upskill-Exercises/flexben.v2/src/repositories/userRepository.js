const db = require('../config/db');

exports.getUser = async ({email, password}) => {
    let sql = `
        SELECT a.*, e.*
        FROM flexben.account as a
        INNER JOIN flexben.employee as e
        ON a.employee_id = e.employee_id
        HAVING e.email = ? AND a.password = ?
     `
    let values = [email, password]
    const user = await db.execute(sql,values)
    return user
}