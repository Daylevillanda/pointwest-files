const db = require('../db/connect');

const {
    generateToken
  } = require("../helper/jwt");

const getAll = async (req, res) => {
    const [rows, fields] = await db.execute('SELECT * FROM `actor`');
    res.status(200).json({ 
        "status": 200,
        "statusText": "OK",
        "message": "All actors retrieved",
        "data": rows,
    });
};

const getSearch = async (req, res) => {
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
        res.status(400).json({ 
            "status": 400,
            "statusText": "BAD REQUEST",
            "message": "Invalid Search",
            "error": "Invalid Search",
        }); 
    }   
};

module.exports = {
    getAll,
    getSearch
};