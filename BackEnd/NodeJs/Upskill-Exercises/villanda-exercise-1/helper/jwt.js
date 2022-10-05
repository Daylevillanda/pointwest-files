const jwt = require("jsonwebtoken");

const {
    STAFF,
    CUST
  } = require('./constants')

const getUsernameFromToken = (token) => jwt.decode(token)["sub"];

exports.generateToken = async function (prevToken, userName) {
    const name = userName || getUsernameFromToken(prevToken);
    const options = {
      algorithm: process.env.ALGORITHM,
      expiresIn: process.env.EXPIRY,
      issuer: process.env.ISSUER,
      subject: name,
      audience: STAFF
    };
    return jwt.sign({}, process.env.SECRET, options);
  };

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