require('dotenv').config();
const cookieParser = require("cookie-parser");
const express = require('express');
const app = express();
const db = require('./db/connect');
const port = process.env.PORT || 5000;

const { verifyToken } = require('./services/jwt')
const { loginController } = require('./controllers/loginController')
const { logoutController } = require('./controllers/logoutController')

const flexCycleCutoffRoute = require('./routes/flexCycleCutoffRoute');

//middlewares
app.use(express.json());
app.use(cookieParser());

// routes
app.get('/', (req, res) => {res.status(200).send(`Welcome to FleXben`)});
app.post('/api/v1/login', loginController);
app.get("/api/v1/logout", verifyToken, logoutController);
app.use("/api/v1/flex-cycle-cutoff", verifyToken, flexCycleCutoffRoute);
app.get('*', (req, res) => {res.status(404).send(`Resource not found`)});

const start = async () => {
  try {
    app.listen(port, () =>
      console.log(`Server is listening on port ${port}...`)
    );
    const connection = await db.connect()
    console.log(`Database connected as id ${connection.connectionId}...`)

  } catch (error) {
    console.log(error);
  }
};

start();
