const Sequelize = require('sequelize');
module.exports = function(sequelize, DataTypes) {
  return sequelize.define('payment', {
    payment_id: {
      autoIncrement: true,
      type: DataTypes.SMALLINT.UNSIGNED,
      allowNull: false,
      primaryKey: true
    },
    customer_id: {
      type: DataTypes.SMALLINT.UNSIGNED,
      allowNull: false,
      references: {
        model: 'customer',
        key: 'customer_id'
      }
    },
    staff_id: {
      type: DataTypes.TINYINT.UNSIGNED,
      allowNull: false,
      references: {
        model: 'staff',
        key: 'staff_id'
      }
    },
    rental_id: {
      type: DataTypes.INTEGER,
      allowNull: true,
      references: {
        model: 'rental',
        key: 'rental_id'
      }
    },
    amount: {
      type: DataTypes.DECIMAL(5,2),
      allowNull: false
    },
    payment_date: {
      type: DataTypes.DATE,
      allowNull: false
    },
    last_update: {
      type: DataTypes.DATE,
      allowNull: true,
      defaultValue: Sequelize.Sequelize.literal('CURRENT_TIMESTAMP')
    }
  }, {
    sequelize,
    tableName: 'payment',
    hasTrigger: true,
    timestamps: false,
    indexes: [
      {
        name: "PRIMARY",
        unique: true,
        using: "BTREE",
        fields: [
          { name: "payment_id" },
        ]
      },
      {
        name: "idx_fk_staff_id",
        using: "BTREE",
        fields: [
          { name: "staff_id" },
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
        name: "fk_payment_rental",
        using: "BTREE",
        fields: [
          { name: "rental_id" },
        ]
      },
    ]
  });
};
