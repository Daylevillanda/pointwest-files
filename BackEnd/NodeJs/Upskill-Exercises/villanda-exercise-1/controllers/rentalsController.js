const db = require('../db/connect');
const { generateToken } = require("../helper/jwt");

const getAll = async (req, res) => {
    const { film, returned, exceeded } = req.query;

    let sql = `
    SELECT *
    FROM sakila.rental    
    `

    const [rows, fields] = await db.execute(sql);
    let filteredResults = [...rows];

    if(film || returned || exceeded){
        if(returned === "false") {
            filteredResults = filteredResults
                .filter(a => a.return_date === null)
        }

        generateToken(req.cookies.token, null).then((token) => {
            res.cookie("token", token, { httpOnly: true });
            res.status(200).json({ 
                "status": 200,
                "statusText": "OK",
                "message": Object.entries(filteredResults).length > 0 ? "Filtered rentals retrieved" : "No items found",
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
                "message": "All rentals retrieved",
                "data": filteredResults,
            }); 
        });
    }   
};

const getById = async (req, res) => {
    const { id } = req.params

    let sql = `
    SELECT *
    FROM sakila.rental
    WHERE rental_id = ?
    `
    const [rows, fields] = await db.execute(sql, [id]);
    
    if(Object.entries(rows).length > 0 )
    {
        generateToken(req.cookies.token, null).then((token) => {
            res.cookie("token", token, { httpOnly: true });
            res.status(200).json({ 
                "status": 200,
                "statusText": "OK",
                "message": "Rental retrieved",
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
                "message": "No rental retrieved",
            });
        });
    }
};

const insert = async (req, res) => {
    const rental = req.body
    const [rows, results, fields] = await db.query('SELECT * FROM `rental` WHERE inventory_id = ? AND return_date IS NULL', [rental.inventory_id]);
    if(Object.entries(rows).length < 1){
        const [rows, results, fields] = await db.query('INSERT INTO `rental` SET ?', [rental]);
        generateToken(req.cookies.token, null).then((token) => {
            res.cookie("token", token, { httpOnly: true });
            res.status(201).json({ 
                "status": 201,
                "statusText": "CREATED",
                "message": "Created successfully",
                "Inserted id" : rows.insertId
            });
        });
    }
    else {
        generateToken(req.cookies.token, null).then((token) => {
            res.cookie("token", token, { httpOnly: true });
            res.status(400).json({ 
                "status": 400,
                "statusText": "BAD REQUEST",
                "message": "Not Available"
            });
        });
    }
};

const update = async (req, res) => {
    const { id } = req.params
    const rental = req.body
    const [rows, results, fields] = await db.query('UPDATE `rental` SET ? WHERE rental_id = ?', [rental, id]);
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
    update
};