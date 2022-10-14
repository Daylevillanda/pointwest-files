const express = require('express')
const router = express.Router()

const { getActiveReimbursement, addReimbursement, removeReimbursement, updateReimbursement } = require('../controllers/fileReimbursementController')
const { generateReimbursement } = require('../controllers/generateController')
const { getFlexPoint } = require('../controllers/flexPointController')

router.route('/')
  .get(getActiveReimbursement)
  .post(addReimbursement)
  .put(updateReimbursement)
router.route('/item/:id')
  .delete(removeReimbursement)

router.route('/generate')
  .get(generateReimbursement)

router.route('/flex-points')
  .post(getFlexPoint)

module.exports = router