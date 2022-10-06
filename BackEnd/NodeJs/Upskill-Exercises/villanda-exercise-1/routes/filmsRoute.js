const express = require('express')
const router = express.Router()

const { canAccess } = require('../helper/routeGuards')

const {
  getAll,
  getById,
  insert,
  remove,
  update
} = require('../controllers/filmsController')

router.route('/')
  .get(getAll)
  .post(canAccess("CREATE_FILM"),insert)

router.route('/:id')
  .get(getById)
  .delete(canAccess("DELETE_FILM"),remove)
  .put(canAccess("EDIT_FILM"),update)

module.exports = router