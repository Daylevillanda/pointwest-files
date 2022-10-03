const Sequelize = require('sequelize');
module.exports = function(sequelize, DataTypes) {
  return sequelize.define('film', {
    film_id: {
      autoIncrement: true,
      type: DataTypes.SMALLINT.UNSIGNED,
      allowNull: false,
      primaryKey: true
    },
    title: {
      type: DataTypes.STRING(255),
      allowNull: false
    },
    description: {
      type: DataTypes.TEXT,
      allowNull: true
    },
    release_year: {
      type: DataTypes.DATE,
      allowNull: true
    },
    language_id: {
      type: DataTypes.TINYINT.UNSIGNED,
      allowNull: false,
      references: {
        model: 'language',
        key: 'language_id'
      }
    },
    original_language_id: {
      type: DataTypes.TINYINT.UNSIGNED,
      allowNull: true,
      references: {
        model: 'language',
        key: 'language_id'
      }
    },
    rental_duration: {
      type: DataTypes.TINYINT.UNSIGNED,
      allowNull: false,
      defaultValue: 3
    },
    rental_rate: {
      type: DataTypes.DECIMAL(4,2),
      allowNull: false,
      defaultValue: 4.99
    },
    length: {
      type: DataTypes.SMALLINT.UNSIGNED,
      allowNull: true
    },
    replacement_cost: {
      type: DataTypes.DECIMAL(5,2),
      allowNull: false,
      defaultValue: 19.99
    },
    rating: {
      type: DataTypes.ENUM('G','PG','PG-13','R','NC-17'),
      allowNull: true,
      defaultValue: "G"
    },
    special_features: {
      type: "SET('TRAILERS','COMMENTARIES','DELETED SCENES','BEHIND THE SCENES')",
      allowNull: true
    },
    last_update: {
      type: DataTypes.DATE,
      allowNull: false,
      defaultValue: Sequelize.Sequelize.literal('CURRENT_TIMESTAMP')
    }
  }, {
    sequelize,
    tableName: 'film',
    hasTrigger: true,
    timestamps: false,
    indexes: [
      {
        name: "PRIMARY",
        unique: true,
        using: "BTREE",
        fields: [
          { name: "film_id" },
        ]
      },
      {
        name: "idx_title",
        using: "BTREE",
        fields: [
          { name: "title" },
        ]
      },
      {
        name: "idx_fk_language_id",
        using: "BTREE",
        fields: [
          { name: "language_id" },
        ]
      },
      {
        name: "idx_fk_original_language_id",
        using: "BTREE",
        fields: [
          { name: "original_language_id" },
        ]
      },
    ]
  });
};
