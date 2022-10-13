const { getRoleFromToken } = require("../../services/jwt");

exports.verifyAccess = (role) => {
    return (req, res, next) => {
        let token = req.cookies.token
        let id = getRoleFromToken(token)
        if(Number(role != Number(id))){
            return res.status(401).json({ 
                "status": 401,
                "statusText": "Unauthorized",
                "message": "Unauthorized"
            })
        }
        next()
    }
}