const jwt = require("jsonwebtoken");

const db = require('../db/connect');

const {
    STAFF,
    CUST
  } = require('./constants')

const getUsernameFromToken = (token) => jwt.decode(token)["sub"];
const getUsernameFromId = async (id) => {
  const [rows, fields] = await db.execute('SELECT * FROM `user` WHERE user_id = ?', [id])
  return rows
}

const getRoleFromToken = (token) => jwt.decode(token)["aud"];

exports.generateToken = async function (prevToken, userName) {

    const user = await getUsernameFromId(userName);
    const name =  user[0]?.email || getUsernameFromToken(prevToken);
    const role = user[0]?.role === "STAFF" ? STAFF : CUST || getRoleFromToken(prevToken);
    const options = {
      algorithm: process.env.ALGORITHM,
      expiresIn: process.env.EXPIRY,
      issuer: process.env.ISSUER,
      subject: name,
      audience: role
    };
    return jwt.sign({}, process.env.SECRET, options);
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