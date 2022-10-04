const express = require('express')
const router = express.Router()

const {
  getAll
} = require('../controllers/filmsController')

router.route('/').get(getAll)

module.exports = router