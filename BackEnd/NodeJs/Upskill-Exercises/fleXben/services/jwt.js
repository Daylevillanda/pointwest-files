const jwt = require("jsonwebtoken");
const db = require('../db/connect');
const {getAccessRights} = require('../config/accessRights');

const getRoleFromToken = (token) => jwt.decode(token)["role"];
const getEmailFromToken = (token) => jwt.decode(token)["sub"];
const getIdFromToken = (token) => jwt.decode(token)["id"];

const generateToken = async function (token, employee) {

  const email =  employee? employee.email : getEmailFromToken(token);
  const role = employee? employee.role_id : getRoleFromToken(token);
  const id = employee? employee.employee_id : getIdFromToken(token);
  const options = {
    algorithm: process.env.ALGORITHM,
    expiresIn: process.env.EXPIRY,
    issuer: process.env.ISSUER,
    subject: email,
    audience: getAccessRights(String(role))
  };

  return jwt.sign({id:id,role:role}, process.env.SECRET, options);
}

const verifyToken = (req, res, next) => {
  const token = req.cookies.token;
  if (!token)
    res.status(401).send({ message: "Not authorized to access data" });
  else {
    jwt.verify(token, process.env.SECRET, function (err) {
      if (err) {
          res.clearCookie("token");
          res.status(401).send({ message: "Please login again" });
      } else next()
    });
  }
};

module.exports = {
  generateToken,
  verifyToken,
  getRoleFromToken,
  getEmailFromToken,
  getIdFromToken
};