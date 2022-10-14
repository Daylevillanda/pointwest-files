const db = require('../db/connect');
const { generateToken } = require("../services/jwt");

const getFlexPoint = async (req, res) => {
    let token = req.cookies.token
    const data = req.body
    const new_token = await generateToken(token, null)
    res.cookie("token", new_token, { httpOnly: true });
    let tax = 0
    let result = (data.monthly_rate/21.75)*data.flex_credit 
    result = result - (result*(tax/100))

    res.status(200).json({ 
        "status": 200,
        "statusText": "OK",
        "message": "Flex point successfully calculated",
        "FlexPoint": result
    });
}

module.exports = {
    getFlexPoint
};