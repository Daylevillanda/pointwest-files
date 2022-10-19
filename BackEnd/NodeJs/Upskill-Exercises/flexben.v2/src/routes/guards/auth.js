const { jwt } = require("../../config/middlewares");

let response = { status:401, statusText:"Unauthorized", data:{} }

exports.verifyToken = async (req, res, next) => {
    const token = req.cookies.token;
    if (!token)
        response = { status:401, statusText:"Unauthorized", data:{error:"Not authorized to access data"} }
    else {
        jwt.verify(token, process.env.SECRET, function (err) {
        if (err) {
            res.clearCookie("token");
            response = { status:401, statusText:"Unauthorized", data:{error:"Please login again"} }
        } else next()
        });
    }
    res.status(response.status).json({ 
        "status": response.status,
        "statusText": response.statusText,
        "data": response.data
    })
};