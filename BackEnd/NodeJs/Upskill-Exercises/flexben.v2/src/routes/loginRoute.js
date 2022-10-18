const {express} = require("../config/middlewares")
const {loginController} = require("../controllers/index")

const router = express.Router()

router.route('/').post(loginController.login)

module.exports = router