const express = require('express')
const router = express.Router()

const { getActiveReimbursement, addReimbursement, removeReimbursement, updateReimbursement } = require('../controllers/fileReimbursementController')
const { generateReimbursement } = require('../controllers/generateController')

router.route('/')
  .get(getActiveReimbursement)
  .post(addReimbursement)
  .put(updateReimbursement)
router.route('/item/:id')
  .delete(removeReimbursement)

router.route('/generate')
  .get(generateReimbursement)

module.exports = router