const {express} = require("../config/middlewares")
const {fileReimbursementController} = require("../controllers/index")

const router = express.Router()

router.route('/')
    .get(fileReimbursementController.getReimbursement)
    .post(fileReimbursementController.addReimbursement)
// router.route('/search').get(reimbursementController.getReimbursementFilter)
// router.route('/:id').get(reimbursementController.getReimbursementById).put(reimbursementController.updateReimbursement)

module.exports = router