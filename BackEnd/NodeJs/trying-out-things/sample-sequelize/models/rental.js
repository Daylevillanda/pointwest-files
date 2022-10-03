const Sequelize = require('sequelize');
module.exports = function(sequelize, DataTypes) {
  return sequelize.define('rental', {
    rental_id: {
      autoIncrement: true,
      type: DataTypes.INTEGER,
      allowNull: false,
      primaryKey: true
    },
    rental_date: {
      type: DataTypes.DATE,
      allowNull: false
    },
    inventory_id: {
      type: DataTypes.MEDIUMINT.UNSIGNED,
      allowNull: false,
      references: {
        model: 'inventory',
        key: 'inventory_id'
      }
    },
    customer_id: {
      type: DataTypes.SMALLINT.UNSIGNED,
      allowNull: false,
      references: {
        model: 'customer',
        key: 'customer_id'
      }
    },
    return_date: {
      type: DataTypes.DATE,
      allowNull: true
    },
    staff_id: {
      type: DataTypes.TINYINT.UNSIGNED,
      allowNull: false,
      references: {
        model: 'staff',
        key: 'staff_id'
      }
    },
    last_update: {
      type: DataTypes.DATE,
      allowNull: false,
      defaultValue: Sequelize.Sequelize.literal('CURRENT_TIMESTAMP')
    }
  }, {
    sequelize,
    tableName: 'rental',
    hasTrigger: true,
    timestamps: false,
    indexes: [
      {
        name: "PRIMARY",
        unique: true,
        using: "BTREE",
        fields: [
          { name: "rental_id" },
        ]
      },
      {
        name: "rental_date",
        unique: true,
        using: "BTREE",
        fields: [
          { name: "rental_date" },
          { name: "inventory_id" },
          { name: "customer_id" },
        ]
      },
      {
        name: "idx_fk_inventory_id",
        using: "BTREE",
        fields: [
          { name: "inventory_id" },
        ]
      },
      {
        name: "idx_fk_customer_id",
        using: "BTREE",
        fields: [
          { name: "customer_id" },
        ]
      },
      {
        name: "idx_fk_staff_id",
        using: "BTREE",
        fields: [
          { name: "staff_id" },
        ]
      },
    ]
  });
};
