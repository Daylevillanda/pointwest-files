const express = require('express')
const router = express.Router()

const {
  getAll,
  getById,
  insert,
  update
} = require('../controllers/rentalsController')

router.route('/')
  .get(getAll)
  .post(insert)

router.route('/:id')
  .get(getById)
  .put(update)

module.exports = router