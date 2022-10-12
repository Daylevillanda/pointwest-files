const express = require('express')
const router = express.Router()

const { getActiveReimbursement, addReimbursement, removeReimbursement, updateReimbursement } = require('../controllers/fileReimbursementController')

router.route('/')
  .get(getActiveReimbursement)
  .post(addReimbursement)
router.route('/:id')
  .delete(removeReimbursement)
  .put(updateReimbursement)

module.exports = router