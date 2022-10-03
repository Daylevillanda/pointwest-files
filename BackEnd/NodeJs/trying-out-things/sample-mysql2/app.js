// get the client
const mysql = require('mysql2');

// create the connection to database
const connection = mysql.createConnection({
  host: 'BMMBQG3',
  user: 'sa',
  password: 'mysqlserver',
  database: 'sakila'
});

// simple query
connection.query(
  'SELECT * FROM `film`', (err, results, fields) => {
    console.log(results);
  }
);