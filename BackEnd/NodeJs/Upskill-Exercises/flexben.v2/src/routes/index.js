const {express} = require("../config/middlewares")
const {auth} = require("./guards/index")
const login = require("./loginRoute")
const logout = require("./logoutRoute")
const router = express.Router()

router.use('/login',login)
router.use('/logout',auth.verifyToken, logout)

module.exports = router