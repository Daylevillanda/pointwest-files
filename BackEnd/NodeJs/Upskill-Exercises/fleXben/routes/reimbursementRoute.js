const express = require('express')
const router = express.Router()

const { getAll, getById, getSearch, update } = require('../controllers/reimbursementController')

router.route('/')
  .get(getAll)

router.route('/search')
  .get(getSearch)

router.route('/:id')
  .get(getById)
  .put(update)

module.exports = router