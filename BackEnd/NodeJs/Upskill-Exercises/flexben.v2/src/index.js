require('dotenv').config();

const { cookieParser, express } = require("./config/middlewares")
const db = require('./config/db');
const routes = require("./routes/index")

const app = express();
app.use(express.json());
app.use(cookieParser());

app.get('/', (req, res) => {res.status(200).send(`Welcome to FleXben v2.0`)});
app.use('/api/v2', routes);

const start = async () => {
try {
    const port = process.env.PORT || 5000;
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