const jwt = require("jsonwebtoken");
const db = require('../db/connect');
const {getAccessRights} = require('../config/accessRights');

exports.generateToken = async function (token, employee) {

    const name =  employee.email;
    const role = employee.role_id;
    const options = {
      algorithm: process.env.ALGORITHM,
      expiresIn: process.env.EXPIRY,
      issuer: process.env.ISSUER,
      subject: name,
      audience: getAccessRights(String(role))
    };
    return jwt.sign({role:role}, process.env.SECRET, options);
  }

  exports.verifyToken = (req, res, next) => {
    const token = req.cookies.token;
    if (!token)
        res.status(401).send({ message: "Not authorized to access data" });
    else {
        jwt.verify(token, process.env.SECRET, function (err) {
        if (err) {
            res.clearCookie("token");
            res.status(401).send({ message: "Please login again" });
        } else next();
        });
    }
};