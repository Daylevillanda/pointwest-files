require('dotenv').config();

const cookieParser = require("cookie-parser");
const express = require('express');

const app = express();

const db = require('./db/connect');

const filmsRoute = require('./routes/filmsRoute');
const actorsRoute = require('./routes/actorsRoute');
const customersRoute = require('./routes/customersRoute');

const { login } = require('./controllers/loginController')
const { verifyToken } = require("./helper/jwt");

//middlewares
app.use(express.json());
app.use(cookieParser());

// routes
app.get('/', (req, res) => {res.status(200).send(`<h1>Welcome to Villanda Skilla 1</h1>`)});
app.post('/login', login);
app.use('/api/v1/films', verifyToken, filmsRoute);
app.use('/api/v1/actors', verifyToken, actorsRoute);
app.use('/api/v1/customers', verifyToken, customersRoute);

app.post('/test', (req, res) => {
  const { test } = req.body
  console.log(test)
});

app.get('*', (req, res) => {
    res.status(404).send(`<h1>Resource not found</h1>`);
});

const port = process.env.PORT || 5000;

const start = async () => {
  try {
    app.listen(port, () =>
      console.log(`Server is listening on port ${port}...`)
    );
  } catch (error) {
    console.log(error);
  }
};

start();