const {express} = require("../config/middlewares")
const login = require("./loginRoute")
const logout = require("./logoutRoute")
const router = express.Router()

router.use('/login',login)
router.use('/logout',logout)

module.exports = router