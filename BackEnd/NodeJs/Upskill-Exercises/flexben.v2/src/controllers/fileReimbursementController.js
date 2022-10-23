const { jwtService, fileReimbursementService } = require("../services/index")

let response = { status:400, statusText:"BAD REQUEST", message: "Something Went Wrong" }

const getReimbursement = async (req, res) => {
    let token = req.cookies.token
    const new_token = await jwtService.generateToken(token, null)
    res.cookie("token", new_token, { httpOnly: true });
    const reimbursement = await fileReimbursementService.getReimbursement(token)
    if(!reimbursement.error){
        if(reimbursement[0]){
            response.message = "Reimbursements retrieved"
        }else{
            response.message = "No reimbursements found"
        }        
        response.status = 200
        response.statusText = "OK"
    }
    response.data = reimbursement
    res.status(200).json(response);
}

module.exports = {
    getReimbursement
}

// const { jwtService, reimbursementService } = require("../services/index")

// let response = { status:400, statusText:"BAD REQUEST", message: "Something Went Wrong" }

// const getReimbursement = async (req, res) => {
//     let token = req.cookies.token
//     const new_token = await jwtService.generateToken(token, null)
//     res.cookie("token", new_token, { httpOnly: true });
//     const reimbursement = await reimbursementService.getReimbursement()
//     if(!reimbursement.error){
//         if(reimbursement[0]){
//             response.message = "Reimbursements retrieved"
//         }else{
//             response.message = "No reimbursements found"
//         }        
//         response.status = 200
//         response.statusText = "OK"
//     }
//     response.data = reimbursement
//     res.status(200).json(response);
// }

// const getReimbursementById = async (req, res) => {
//     const { id } = req.params
//     let token = req.cookies.token
//     const new_token = await jwtService.generateToken(token, null)
//     res.cookie("token", new_token, { httpOnly: true });
//     const reimbursement = await reimbursementService.getReimbursementById(id)
//     if(!reimbursement.error){
//         if(reimbursement[0]){
//             response.message = "Reimbursement retrieved"
//         }else{
//             response.message = "No reimbursement found"
//         }        
//         response.status = 200
//         response.statusText = "OK"
//     }
//     response.data = reimbursement
//     res.status(200).json(response);
// }

// const getReimbursementFilter = async (req, res) => {
//     let query = req.query
//     let token = req.cookies.token
//     const new_token = await jwtService.generateToken(token, null)
//     res.cookie("token", new_token, { httpOnly: true });
//     const reimbursement = await reimbursementService.getReimbursementFilter(query)
//     if(!reimbursement.error){
//         if(reimbursement[0]){
//             response.message = "Filtered Reimbursements retrieved"
//         }else{
//             response.message = "No reimbursements found"
//         }        
//         response.status = 200
//         response.statusText = "OK"
//     }
//     response.data = reimbursement
//     res.status(200).json(response);
// }

// const updateReimbursement = async (req, res) => {
//     const { id } = req.params
//     const body = req.body
//     let token = req.cookies.token
//     const new_token = await jwtService.generateToken(token, null)
//     res.cookie("token", new_token, { httpOnly: true });
//     const reimbursement = await reimbursementService.updateReimbursement(id,body)
//     if(!reimbursement.error){       
//         response.status = 200
//         response.statusText = "OK"
//         response.message = `Reimbursement successfully '${body.action.toLowerCase()}'`
//     }
//     response.data = reimbursement
//     res.status(200).json(response);
// }


// module.exports = {
//     getReimbursement,
//     getReimbursementById,
//     getReimbursementFilter,
//     updateReimbursement
// }