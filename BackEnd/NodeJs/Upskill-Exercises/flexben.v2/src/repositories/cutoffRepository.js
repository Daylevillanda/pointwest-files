const db = require('../config/db');

exports.getCutoff = async () => {
    let sql = `
    SELECT * 
    FROM flexben.flex_cycle_cutoff 
    WHERE is_active = "y"
     `
    return await db.execute(sql)
}