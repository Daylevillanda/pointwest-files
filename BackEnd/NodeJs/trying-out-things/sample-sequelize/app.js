const { Sequelize } = require('sequelize');
const models = require("./models/init-models")

const sequelize = new Sequelize('sakila', 'sa', 'mysqlserver', {
    host: 'BMMBQG3',
    dialect: 'mysql'
  });


// const start = async () => {
//     try {
//         await sequelize.authenticate();
//         console.log('Connection has been established successfully.');
//     } catch (error) {
//         console.error('Unable to connect to the database:', error);
//     }
// };

// start();

(async () => {
    await sequelize.sync({ force: true });
    // Code here
    let Actor = models(sequelize).actor;
    // console.log(await Actor.findAll());
    console.log(await Actor.findAll({where: {Actor_id : 2}}));

    // use json stringfiy to remove other stuffs <<----------------
    // let result = await Actor.findAll({where: {Actor_id : 2}});
    // console.log(JSON.stringify(result));
  })();