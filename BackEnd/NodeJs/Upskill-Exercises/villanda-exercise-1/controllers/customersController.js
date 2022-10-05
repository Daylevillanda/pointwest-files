const db = require('../db/connect');
const { generateToken } = require("../helper/jwt");

const getAll = async (req, res) => {
    const { first_name, last_name, country } = req.query;

    let sql = `
    SELECT *
    FROM sakila.customer 
    `

    const [rows, fields] = await db.execute(sql);
    let filteredResults = [...rows];

    if(first_name || last_name || country){
        if(first_name) {
            filteredResults = filteredResults
                .filter(a => (String(a.first_name
                        .toLowerCase())
                        .startsWith(first_name.toLowerCase())))
        }

        if(last_name) {
            filteredResults = filteredResults
                .filter(a => (String(a.last_name
                        .toLowerCase())
                        .startsWith(last_name.toLowerCase())))
        }

        if(country) {         
            let sql = `
            SELECT a.customer_id, a.address_id, a.city_id, ci.country_id 
            FROM sakila.city as ci
            INNER JOIN (
                SELECT c.customer_id, c.address_id, a.city_id
                FROM sakila.customer as c
                INNER JOIN sakila.address AS a 
                ON c.address_id = a.address_id
                ) AS a 
            ON ci.city_id = a.city_id
            HAVING ci.country_id = ?
            `   
            const [rows, fields] = await db.execute(sql, [country]);
            filteredResults = filteredResults.filter(({customer_id}) => (rows.find(r => (customer_id == r.customer_id))))
        }

        generateToken(req.cookies.token, null).then((token) => {
            res.cookie("token", token, { httpOnly: true });
            res.status(200).json({ 
                "status": 200,
                "statusText": "OK",
                "message": Object.entries(filteredResults).length > 0 ? "Filtered customers retrieved" : "No items found",
                "data": filteredResults,
            });
        });        
    }
    else {
        generateToken(req.cookies.token, null).then((token) => {
            res.cookie("token", token, { httpOnly: true });
            res.status(200).json({ 
                "status": 200,
                "statusText": "OK",
                "message": "All customers retrieved",
                "data": filteredResults,
            }); 
        });
    }   
};

const getById = async (req, res) => {
    const { id } = req.params

    let sql = `
    SELECT *
    FROM sakila.customer 
    WHERE customer_id = ?
    `

    const [rows, fields] = await db.execute(sql, [id]);
    generateToken(req.cookies.token, null).then((token) => {
        res.cookie("token", token, { httpOnly: true });
        res.status(200).json({ 
            "status": 200,
            "statusText": "OK",
            "message": "Customer retrieved",
            "data": rows[0],
        });
    });
};

module.exports = {
    getAll,
    getById
};