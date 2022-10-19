const { jwt } = require("../../config/middlewares");

let response = { status:401, statusText:"Unauthorized"}

exports.verifyToken = async (req, res, next) => {
    const token = req.cookies.token;
    if (!token){
        response.data = {error: "Not authorized to access data" }
    }
    else {
        jwt.verify(token, process.env.SECRET, function (err) {
            if (err) {
                res.clearCookie("token")
                response.data = {error: "Please login again"}
            }
        });
    }
    if(response.data){
        res.status(response.status).json({ 
            "status": response.status,
            "statusText": response.statusText,
            "data": response.data
        })
        delete response.data
    }
    else next()
};