const express = require('express')
const router = express.Router()

const {
  getAll,
  getById,
  insert,
  remove,
  update
} = require('../controllers/actorsController')

router.route('/').get(getAll).post(insert)
router.route('/:id').get(getById).delete(remove).put(update)

module.exports = router