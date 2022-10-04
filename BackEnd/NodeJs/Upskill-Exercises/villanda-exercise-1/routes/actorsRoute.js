const express = require('express')
const router = express.Router()

const {
  getAll,
  getSearch
} = require('../controllers/actorsController')

router.route('/').get(getAll)
router.route('/search').get(getSearch)

module.exports = router