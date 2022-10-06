const express = require('express')
const router = express.Router()

const {
  getAll,
  getById,
  insert,
  remove,
  update
} = require('../controllers/actorsController')

const { canAccess } = require('../helper/routeGuards')

router.route('/')
  .get(getAll)
  .post(canAccess("CREATE_ACTOR"),insert)
router.route('/:id')
  .get(getById)
  .delete(canAccess("DELETE_ACTOR"),remove)
  .put(canAccess("EDIT_ACTOR"),update)

module.exports = router