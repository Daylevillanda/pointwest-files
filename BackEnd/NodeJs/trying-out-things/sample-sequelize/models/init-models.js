var DataTypes = require("sequelize").DataTypes;
var _actor = require("./actor");
var _address = require("./address");
var _category = require("./category");
var _city = require("./city");
var _country = require("./country");
var _customer = require("./customer");
var _film = require("./film");
var _film_actor = require("./film_actor");
var _film_category = require("./film_category");
var _film_text = require("./film_text");
var _inventory = require("./inventory");
var _language = require("./language");
var _payment = require("./payment");
var _rental = require("./rental");
var _staff = require("./staff");
var _store = require("./store");

function initModels(sequelize) {
  var actor = _actor(sequelize, DataTypes);
  var address = _address(sequelize, DataTypes);
  var category = _category(sequelize, DataTypes);
  var city = _city(sequelize, DataTypes);
  var country = _country(sequelize, DataTypes);
  var customer = _customer(sequelize, DataTypes);
  var film = _film(sequelize, DataTypes);
  var film_actor = _film_actor(sequelize, DataTypes);
  var film_category = _film_category(sequelize, DataTypes);
  var film_text = _film_text(sequelize, DataTypes);
  var inventory = _inventory(sequelize, DataTypes);
  var language = _language(sequelize, DataTypes);
  var payment = _payment(sequelize, DataTypes);
  var rental = _rental(sequelize, DataTypes);
  var staff = _staff(sequelize, DataTypes);
  var store = _store(sequelize, DataTypes);

  actor.belongsToMany(film, { as: 'film_id_films', through: film_actor, foreignKey: "actor_id", otherKey: "film_id" });
  category.belongsToMany(film, { as: 'film_id_film_film_categories', through: film_category, foreignKey: "category_id", otherKey: "film_id" });
  film.belongsToMany(actor, { as: 'actor_id_actors', through: film_actor, foreignKey: "film_id", otherKey: "actor_id" });
  film.belongsToMany(category, { as: 'category_id_categories', through: film_category, foreignKey: "film_id", otherKey: "category_id" });
  film_actor.belongsTo(actor, { as: "actor", foreignKey: "actor_id"});
  actor.hasMany(film_actor, { as: "film_actors", foreignKey: "actor_id"});
  customer.belongsTo(address, { as: "address", foreignKey: "address_id"});
  address.hasMany(customer, { as: "customers", foreignKey: "address_id"});
  staff.belongsTo(address, { as: "address", foreignKey: "address_id"});
  address.hasMany(staff, { as: "staffs", foreignKey: "address_id"});
  store.belongsTo(address, { as: "address", foreignKey: "address_id"});
  address.hasMany(store, { as: "stores", foreignKey: "address_id"});
  film_category.belongsTo(category, { as: "category", foreignKey: "category_id"});
  category.hasMany(film_category, { as: "film_categories", foreignKey: "category_id"});
  address.belongsTo(city, { as: "city", foreignKey: "city_id"});
  city.hasMany(address, { as: "addresses", foreignKey: "city_id"});
  city.belongsTo(country, { as: "country", foreignKey: "country_id"});
  country.hasMany(city, { as: "cities", foreignKey: "country_id"});
  payment.belongsTo(customer, { as: "customer", foreignKey: "customer_id"});
  customer.hasMany(payment, { as: "payments", foreignKey: "customer_id"});
  rental.belongsTo(customer, { as: "customer", foreignKey: "customer_id"});
  customer.hasMany(rental, { as: "rentals", foreignKey: "customer_id"});
  film_actor.belongsTo(film, { as: "film", foreignKey: "film_id"});
  film.hasMany(film_actor, { as: "film_actors", foreignKey: "film_id"});
  film_category.belongsTo(film, { as: "film", foreignKey: "film_id"});
  film.hasMany(film_category, { as: "film_categories", foreignKey: "film_id"});
  inventory.belongsTo(film, { as: "film", foreignKey: "film_id"});
  film.hasMany(inventory, { as: "inventories", foreignKey: "film_id"});
  rental.belongsTo(inventory, { as: "inventory", foreignKey: "inventory_id"});
  inventory.hasMany(rental, { as: "rentals", foreignKey: "inventory_id"});
  film.belongsTo(language, { as: "language", foreignKey: "language_id"});
  language.hasMany(film, { as: "films", foreignKey: "language_id"});
  film.belongsTo(language, { as: "original_language", foreignKey: "original_language_id"});
  language.hasMany(film, { as: "original_language_films", foreignKey: "original_language_id"});
  payment.belongsTo(rental, { as: "rental", foreignKey: "rental_id"});
  rental.hasMany(payment, { as: "payments", foreignKey: "rental_id"});
  payment.belongsTo(staff, { as: "staff", foreignKey: "staff_id"});
  staff.hasMany(payment, { as: "payments", foreignKey: "staff_id"});
  rental.belongsTo(staff, { as: "staff", foreignKey: "staff_id"});
  staff.hasMany(rental, { as: "rentals", foreignKey: "staff_id"});
  store.belongsTo(staff, { as: "manager_staff", foreignKey: "manager_staff_id"});
  staff.hasOne(store, { as: "manager_staff_store", foreignKey: "manager_staff_id"});
  customer.belongsTo(store, { as: "store", foreignKey: "store_id"});
  store.hasMany(customer, { as: "customers", foreignKey: "store_id"});
  inventory.belongsTo(store, { as: "store", foreignKey: "store_id"});
  store.hasMany(inventory, { as: "inventories", foreignKey: "store_id"});
  staff.belongsTo(store, { as: "store", foreignKey: "store_id"});
  store.hasMany(staff, { as: "staffs", foreignKey: "store_id"});

  return {
    actor,
    address,
    category,
    city,
    country,
    customer,
    film,
    film_actor,
    film_category,
    film_text,
    inventory,
    language,
    payment,
    rental,
    staff,
    store,
  };
}
module.exports = initModels;
module.exports.initModels = initModels;
module.exports.default = initModels;
