const Sequelize = require('sequelize');
module.exports = function(sequelize, DataTypes) {
  return sequelize.define('film_text', {
    film_id: {
      type: DataTypes.SMALLINT,
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
    }
  }, {
    sequelize,
    tableName: 'film_text',
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
        name: "idx_title_description",
        type: "FULLTEXT",
        fields: [
          { name: "title" },
          { name: "description" },
        ]
      },
    ]
  });
};
