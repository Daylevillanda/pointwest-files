const {express} = require("../config/middlewares")
const {reimbursementController} = require("../controllers/index")

const router = express.Router()

router.route('/').get(reimbursementController.getReimbursement)
router.route('/:id').get(reimbursementController.getReimbursementById)

module.exports = router