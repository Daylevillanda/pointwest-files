const jwt = require("jsonwebtoken");

exports.canAccess = (access) => {
    return (req, res, next) => {
        const token = req.cookies.token
        const audience = jwt.decode(token)["aud"]
        if(audience.includes(access)){
          next()
        }
        else{
          res.status(401).send({ message: "Unauthorized" })
        }
    }
}