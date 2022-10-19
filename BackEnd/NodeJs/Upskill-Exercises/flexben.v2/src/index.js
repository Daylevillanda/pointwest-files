require('dotenv').config();

const { cookieParser, express } = require("./config/middlewares")
const db = require('./config/db');
const {login,logout,reimbursement} = require("./routes/index")
const {auth} = require("./routes/guards/index")

const app = express();
const router = express.Router()
app.use(express.json());
app.use(cookieParser());

app.get('/', (req, res) => {res.status(200).send(`Welcome to FleXben v2.0`)});
router.use('/login',login)
router.use('/logout',auth.verifyToken, logout)
router.use('/reimbursement',auth.verifyToken, reimbursement)
app.use('/api/v2', router);

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