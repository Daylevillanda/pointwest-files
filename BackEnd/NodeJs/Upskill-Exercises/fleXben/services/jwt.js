const jwt = require("jsonwebtoken");
const db = require('../db/connect');
const {getAccessRights} = require('../config/accessRights');

const getRoleFromToken = (token) => jwt.decode(token)["role"];
const getEmailFromToken = (token) => jwt.decode(token)["sub"];

const generateToken = async function (token, employee) {

  const email =  employee? employee.email : getEmailFromToken(token);
  const role = employee? employee.role_id : getRoleFromToken(token);
  const options = {
    algorithm: process.env.ALGORITHM,
    expiresIn: process.env.EXPIRY,
    issuer: process.env.ISSUER,
    subject: email,
    audience: getAccessRights(String(role))
  };

  if(token){
    const [rows, results, fields] = await db.query('INSERT INTO `token` SET ?', [{value:token}]);
  }

  return jwt.sign({role:role}, process.env.SECRET, options);
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
      } else {
        db.query('SELECT * FROM `token` WHERE value LIKE ?', [`${token}%`]).then((results)=>{
          if(Object.entries(results[0]).length > 0 ) {
            res.clearCookie("token");
            res.status(401).send({ message: "Please login again" });
          }
          else next()
        });
      };
    });
  }
};

module.exports = {
  generateToken,
  verifyToken,
  getRoleFromToken,
  getEmailFromToken
};