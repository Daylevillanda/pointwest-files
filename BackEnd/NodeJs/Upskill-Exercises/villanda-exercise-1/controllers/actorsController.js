const db = require('../db/connect');

const {
    generateToken
  } = require("../helper/jwt");

const getAll = async (req, res) => {
    const { first_name, last_name } = req.query;

    const [rows, fields] = await db.execute('SELECT * FROM `actor`');
    let filteredResults = [...rows];

    if(first_name || last_name){
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
        generateToken(req.cookies.token, null).then((token) => {
            res.cookie("token", token, { httpOnly: true });
            res.status(200).json({ 
                "status": 200,
                "statusText": "OK",
                "message": Object.entries(filteredResults).length > 0 ? "Filtered actors retrieved" : "No items found",
                "data": filteredResults,
            });
        });        
    }
    else{ 
        generateToken(req.cookies.token, null).then((token) => {
            res.cookie("token", token, { httpOnly: true });
            res.status(200).json({ 
                "status": 200,
                "statusText": "OK",
                "message": "All actors retrieved",
                "data": rows,
            });
        });
    }  
};

const getById = async (req, res) => {
    const { id } = req.params
    const [rows, fields] = await db.execute('SELECT * FROM `actor` WHERE actor_id = ?', [id]);
    generateToken(req.cookies.token, null).then((token) => {
        res.cookie("token", token, { httpOnly: true });
        res.status(200).json({ 
            "status": 200,
            "statusText": "OK",
            "message": "Actor retrieved",
            "data": rows[0],
        });
    });
};

const insert = async (req, res) => {
    const actor = req.body
    const [rows, results, fields] = await db.query('INSERT INTO `actor` SET ?', [actor]);
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
    const [rows, results, fields] = await db.query('DELETE FROM `actor` WHERE actor_id = ?', [id]);
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
    const actor = req.body
    const [rows, results, fields] = await db.query('UPDATE `actor` SET ? WHERE actor_id = ?', [actor, id]);
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