const express = require('express')
const router = express.Router()

const { getAll } = require('../controllers/flexCycleCutoffController')

router.route('/')
  .get(getAll)

module.exports = router