const db = require('../db/connect');

const getAll = async (req, res) => {
    const [rows, fields] = await db.execute('SELECT * FROM `actor`');
    res.status(200).json({ 
        "status": 200,
        "statusText": "OK",
        "message": "All actors retrieved",
        "data": rows,
    });
};

module.exports = {
    getAll
};