const { jwt } = require("../config/middlewares");
const db = require('../config/db');

const getRoleFromToken = (token) => jwt.decode(token)["role"];
const getEmailFromToken = (token) => jwt.decode(token)["sub"];
const getIdFromToken = (token) => jwt.decode(token)["id"];

const generateToken = async function (token, user) {
  const email =  user? user.email : getEmailFromToken(token);
  const role = user? user.role_id : getRoleFromToken(token);
  const id = user? user.employee_id : getIdFromToken(token);
  const options = {
    algorithm: process.env.ALGORITHM,
    expiresIn: process.env.EXPIRY,
    issuer: process.env.ISSUER,
    subject: email,
    audience: []
  };
  return jwt.sign({id:id,role:role}, process.env.SECRET, options);
}

module.exports = {
  generateToken,
  getRoleFromToken,
  getEmailFromToken,
  getIdFromToken
};