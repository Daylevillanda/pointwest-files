const express = require('express')
const router = express.Router()

const jwt = require("jsonwebtoken");

const {
  getAll,
  getById,
  insert,
  remove,
  update
} = require('../controllers/filmsController')
router.route('/').get((req, res, next) => {
  const token = req.cookies.token
  const audience = jwt.decode(token)["aud"]
  if(audience.includes("SHOW_FILM")){
    next()
  }
  else{
    res.status(401).send({ message: "Unauthorized" })
  }
},getAll)
  .post((req, res, next) => {
    const token = req.cookies.token
    const audience = jwt.decode(token)["aud"]
    if(audience.includes("CREATE_FILM")){
      next()
    }
    else{
      res.status(401).send({ message: "Unauthorized" })
    }
  },insert)

router.route('/:id').get((req, res, next) => {
  const token = req.cookies.token
  const audience = jwt.decode(token)["aud"]
  if(audience.includes("SHOW_FILM")){
    next()
  }
  else{
    res.status(401).send({ message: "Unauthorized" })
  }
},getById)
  .delete((req, res, next) => {
    const token = req.cookies.token
    const audience = jwt.decode(token)["aud"]
    if(audience.includes("DELETE_FILM")){
      next()
    }
    else{
      res.status(401).send({ message: "Unauthorized" })
    }
  },remove)
  .put((req, res, next) => {
    const token = req.cookies.token
    const audience = jwt.decode(token)["aud"]
    if(audience.includes('EDIT_FILM')){
      next()
    }
    else{
      res.status(401).send({ message: "Unauthorized" })
    }
  },update)

module.exports = router