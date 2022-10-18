const { loginService, jwtService } = require("../services/index")

const login = async (req, res) => {
    const credentials = req.body
    const user = await loginService.validateCredential(credentials)
    const token = await jwtService.generateToken(null, user)
    res.cookie("token", token, { httpOnly: true });
    res.status(200).json({ 
        "status": 200,
        "statusText": "OK",
        "user": user
    })
};

module.exports = {
    login
}