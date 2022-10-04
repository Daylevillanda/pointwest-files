// get the client
// const mysql = require('mysql2');

// // create the connection to database
// const connection = mysql.createConnection({
//   host: 'BMMBQG3',
//   user: 'sa',
//   password: 'mysqlserver',
//   database: 'sakila'
// });

// // simple query
// connection.query(
//   'SELECT * FROM `film` LIMIT 3', (err, results, fields) => {
//     console.log(results);
//   }
// );


//using promise
const mysql = require('mysql2/promise');
const start = async () => {
  try {
    const connection = await mysql.createConnection({
      host: 'BMMBQG3',
      user: 'sa',
      password: 'mysqlserver',
      database: 'sakila'
    });
    const [rows, fields] = await connection.execute('SELECT * FROM `film` Limit 3');
    console.log(rows)
  } catch (error) {
    console.log(error);
  }
};

start();




// hiwalay na file

//connect.js
// const mysql = require('mysql2');

// module.exports =  async () => {
//     const connection = await mysql.createConnection({
//         host: 'BMMBQG3',
//         user: 'sa',
//         password: 'mysqlserver',
//         database: 'sakila'
//     });
//     return connection.promise()
// }

//index.js
// const start = async () => {
//   try {
//     const connection = await db()
//     const [rows, fields] = await connection.execute('SELECT * FROM `film` Limit 3');
//     console.log(JSON.stringify(rows));
//     app.listen(port, () =>
//       console.log(`Server is listening on port ${port}...`)
//     );
//   } catch (error) {
//     console.log(error);
//   }
// };
