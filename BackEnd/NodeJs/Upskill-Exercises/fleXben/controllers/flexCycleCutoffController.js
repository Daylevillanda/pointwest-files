const db = require('../db/connect');
const { generateToken} = require("../services/jwt");

const getAll = async (req, res) => {
    let token = req.cookies.token
    const new_token = await generateToken(token, null)
    res.cookie("token", new_token, { httpOnly: true });
    res.status(200).json({ 
        "status": 200,
        "statusText": "OK",
        "message": "All actors retrieved",
        "data": token,
    });

};

module.exports = {
    getAll
};