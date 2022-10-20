const {express} = require("../config/middlewares")
const {reimbursementController} = require("../controllers/index")

const router = express.Router()

router.route('/').get(reimbursementController.getReimbursement)
router.route('/search').get(reimbursementController.getReimbursementFilter)
router.route('/:id').get(reimbursementController.getReimbursementById).put(reimbursementController.updateReimbursement)

module.exports = router