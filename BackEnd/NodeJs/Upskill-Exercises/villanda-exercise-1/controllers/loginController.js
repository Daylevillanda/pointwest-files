const db = require('../db/connect');

const {
    generateToken
  } = require("../helper/jwt");

exports.login = async (req, res) => {
    const { email } = req.body
    const [rows, fields] = await db.execute('SELECT * FROM `customer` WHERE `email` = ?', [email]);
    if(Object.entries(rows).length > 0){
        generateToken(null, email).then((token) => {
            res.cookie("token", token, { httpOnly: true });
            res.status(200).json({ 
                "status": 200,
                "statusText": "OK",
                "message": "Login Successfuly",
                "data": { 
                    user_id: rows[0].customer_id,
                    userName: rows[0].email
                }
            });
        });
    }
    else { res.status(401).json({ 
        "status": 401,
        "statusText": "Unauthorized",
        "message": "Login Failed"
    })}
};