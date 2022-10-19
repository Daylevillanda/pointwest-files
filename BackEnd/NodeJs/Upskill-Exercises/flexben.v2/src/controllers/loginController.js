const { loginService, jwtService } = require("../services/index")

let response = { status:401, statusText:"Unauthorized" }

const login = async (req, res) => {
    const credentials = req.body
    const user = await loginService.validateCredential(credentials)
    if(!user.error){
        const token = await jwtService.generateToken(null, user)
        res.cookie("token", token, { httpOnly: true });
        response = { status:200, statusText:"OK" }
    }
    res.status(response.status).json({ 
        "status": response.status,
        "statusText": response.statusText,
        "data": user
    })
};

module.exports = {
    login
}