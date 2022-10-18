const {express} = require("../config/middlewares")
const {logoutController} = require("../controllers/index")

const router = express.Router()

router.route('/').get(logoutController.logout)

module.exports = router