const express = require('express')
const router = express.Router()

const {
  getAll,
  getById
} = require('../controllers/actorsController')

router.route('/').get(getAll)
router.route('/:id').get(getById)

module.exports = router