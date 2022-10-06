const db = require('../db/connect');
const { generateToken } = require("../helper/jwt");

const getAll = async (req, res) => {
    const { title, category_id, last_name } = req.query;

    let sql = `
    SELECT f.*, COUNT(f.film_id) AS Stock
    FROM sakila.film as f
    LEFT JOIN (
        SELECT i.*, r.rental_id
        FROM sakila.inventory as i
        LEFT JOIN (
            SELECT * 
            FROM sakila.rental 
            WHERE return_date IS NULL
            ) AS r 
        ON i.inventory_id = r.inventory_id
        HAVING r.rental_id IS NULL
        ) as i 
    ON f.film_id = i.film_id
    GROUP BY f.film_id
    `

    const [rows, fields] = await db.execute(sql);
    let filteredResults = [...rows];

    if(title || category_id || last_name){
        if(title) {
            filteredResults = filteredResults
                .filter(a => (String(a.title
                        .toLowerCase())
                        .includes(title.toLowerCase())))
        }

        if(category_id) { 
            // ----------------> if search by category name        
            // let sql = `
            // SELECT category.category_id, category.name, film_category.film_id
            // FROM category 
            // INNER JOIN film_category ON category.category_id = film_category.category_id
            // HAVING category.name = ?
            // ` 

            // ----------------> if search by category id 
            let sql = `
            SELECT * 
            FROM sakila.film_category 
            WHERE category_id = ?
            `  
            const [rows, fields] = await db.execute(sql, [category_id]);
            filteredResults = filteredResults.filter(({film_id}) => (rows.find(r => (film_id == r.film_id))))
        }

        if(last_name) {         
            let sql = `
            SELECT actor.last_name, actor.actor_id, film_actor.film_id
            FROM actor 
            INNER JOIN film_actor ON actor.actor_id = film_actor.actor_id
            HAVING actor.last_name LIKE ?
            `   
            const [rows, fields] = await db.execute(sql, [`${last_name}%`]);
            filteredResults = filteredResults.filter(({film_id}) => (rows.find(r => (film_id == r.film_id))))
        }
        generateToken(req.cookies.token, null).then((token) => {
            res.cookie("token", token, { httpOnly: true });
            res.status(200).json({ 
                "status": 200,
                "statusText": "OK",
                "message": Object.entries(filteredResults).length > 0 ? "Filtered films retrieved" : "No items found",
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
                "message": "All films retrieved",
                "data": filteredResults,
            }); 
        });
    }   
};

const getById = async (req, res) => {
    const { id } = req.params

    let sql = `
    SELECT f.*, COUNT(f.film_id) AS Stock
    FROM sakila.film as f
    LEFT JOIN (
        SELECT i.*, r.rental_id
        FROM sakila.inventory as i
        LEFT JOIN (
            SELECT * 
            FROM sakila.rental 
            WHERE return_date IS NULL
            ) AS r 
        ON i.inventory_id = r.inventory_id
        HAVING r.rental_id IS NULL
        ) as i 
    ON f.film_id = i.film_id
    GROUP BY f.film_id
    HAVING f.film_id = ?
    `
    const [rows, fields] = await db.execute(sql, [id]);
    
    if(Object.entries(rows).length > 0 )
    {
        generateToken(req.cookies.token, null).then((token) => {
            res.cookie("token", token, { httpOnly: true });
            res.status(200).json({ 
                "status": 200,
                "statusText": "OK",
                "message": "Film retrieved",
                "data": rows[0],
            });
        });
    }
    else {
        generateToken(req.cookies.token, null).then((token) => {
            res.cookie("token", token, { httpOnly: true });
            res.status(404).json({ 
                "status": 404,
                "statusText": "NOT FOUND",
                "message": "No film retrieved",
            });
        });
    }
};

const insert = async (req, res) => {
    const film = req.body
    const [rows, results, fields] = await db.query('INSERT INTO `film` SET ?', [film]);
    generateToken(req.cookies.token, null).then((token) => {
        res.cookie("token", token, { httpOnly: true });
        res.status(201).json({ 
            "status": 201,
            "statusText": "CREATED",
            "message": "Created successfully",
            "Inserted id" : rows.insertId
        });
    });
};

const remove = async (req, res) => {
    const { id } = req.params
    const [rows, results, fields] = await db.query('DELETE FROM `film` WHERE film_id = ?', [id]);
    generateToken(req.cookies.token, null).then((token) => {
        res.cookie("token", token, { httpOnly: true });
        res.status(200).json({ 
            "status": 200,
            "statusText": "OK",
            "message": "Deleted successfully"
        });
    });
};

const update = async (req, res) => {
    const { id } = req.params
    const film = req.body
    const [rows, results, fields] = await db.query('UPDATE `film` SET ? WHERE film_id = ?', [film, id]);
    generateToken(req.cookies.token, null).then((token) => {
        res.cookie("token", token, { httpOnly: true });
        res.status(200).json({ 
            "status": 200,
            "statusText": "OK",
            "message": "Updated successfully"
        });
    });
};

module.exports = {
    getAll,
    getById,
    insert,
    remove,
    update
};