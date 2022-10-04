const db = require('../db/connect');
const { generateToken } = require("../helper/jwt");

const getAll = async (req, res) => {
    const [rows, fields] = await db.execute('SELECT * FROM `film`');
    res.status(200).json({ 
        "status": 200,
        "statusText": "OK",
        "message": "All films retrieved",
        "data": rows,
    });
};

const getSearch = async (req, res) => {
    const { title, genre, last_name, available } = req.query;

    const [rows, fields] = await db.execute('SELECT * FROM `film`');
    let filteredResults = [...rows];

    if(title || genre || last_name || available){
        if(title) {
            filteredResults = filteredResults
                .filter(a => (String(a.title
                        .toLowerCase())
                        .startsWith(title.toLowerCase())))
        }

        if(genre) {         
            let sql = `
            SELECT category.category_id, category.name, film_category.film_id
            FROM category 
            INNER JOIN film_category ON category.category_id = film_category.category_id
            HAVING category.name = ?
            `   
            const [rows, fields] = await db.execute(sql, [genre]);
            filteredResults = filteredResults.filter(({film_id}) => (rows.find(r => (film_id == r.film_id))))
        }

        // if(last_name) {
        //     const [rows, fields] = await db.execute('SELECT * FROM `film_category` WHERE category_id = ?', [Number(genre)]);
        //     filteredResults = filteredResults.filter(({film_id}) => (rows.find(r => (film_id == r.film_id))))
        // }
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