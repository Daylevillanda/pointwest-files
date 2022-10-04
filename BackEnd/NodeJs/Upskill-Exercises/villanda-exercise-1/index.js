require('dotenv').config();
const express = require('express');
const app = express();

const db = require('./db/connect');

const filmsRoute = require('./routes/filmsRoute');
const actorsRoute = require('./routes/actorsRoute');

//middlewares
app.use(express.json());

// routes
app.get('/', (req, res) => {
    res.status(200).send(`<h1>Welcome to Villanda Skilla 1</h1>`)
});
app.use('/api/v1/films', filmsRoute);
app.use('/api/v1/actors', actorsRoute);
// app.use('/api/v1/auth', authRouter);
// app.use('/api/v1/jobs', authenticateUser, jobsRouter);
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