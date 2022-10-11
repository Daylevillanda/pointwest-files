const db = require('../db/connect');
const { generateToken} = require("../services/jwt");

const getAll = async (req, res) => {
    const token = await generateToken(req.cookies.token, null)
    res.cookie("token", token, { httpOnly: true });
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