const express = require('express')
const router = express.Router()

const {
  getAll,
  getById
} = require('../controllers/customersController')

router.route('/').get((req, res, next) => {
  const token = req.cookies.token
  const audience = jwt.decode(token)["aud"]
  if(audience.includes("SHOW_CUSTOMER")){
    next()
  }
  else{
    res.status(401).send({ message: "Unauthorized" })
  }
},getAll)
router.route('/:id').get((req, res, next) => {
  const token = req.cookies.token
  const audience = jwt.decode(token)["aud"]
  if(audience.includes("SHOW_CUSTOMER")){
    next()
  }
  else{
    res.status(401).send({ message: "Unauthorized" })
  }
},getById)

module.exports = router