const db = require('../db/connect');

const {generateToken} = require("../services/jwt");

exports.loginController = async (req, res) => {
    const { email, password } = req.body
    const [rows] = await db.execute('SELECT * FROM `employee` WHERE `is_active` = "y" AND `email` = ?', [email]);
    let employee = [...rows]
    
    if(Object.entries(employee).length > 0){
        const [rows] = await db.execute('SELECT * FROM `account` WHERE `is_active` = "y" AND `employee_id` = ? AND `password` = ?', [employee[0].employee_id,password])
        if(Object.entries(rows).length > 0){
            const token = await generateToken(null, employee[0])
            res.cookie("token", token, { httpOnly: true });
            return res.status(200).json({ 
                "status": 200,
                "statusText": "OK",
                "message": "Login Successfuly",
                "data": employee
            });
        }
    }

    res.status(403).json({ 
        "status": 403,
        "statusText": "FORBIDDEN",
        "message": "Wrong Email/Password"
    })
};