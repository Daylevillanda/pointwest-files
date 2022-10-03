const express = require("express")
const app = express()
const router = express.Router()

router.get('/', (req, res, next) => {
    res.send("Apple")
})

app.use('/api/', router)

app.listen(5000, () =>{
    console.log('Server is running on http://localhost:5000..')
})