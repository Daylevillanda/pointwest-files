const { fileReimbursementRepository } = require("../repositories/index")
const { mapReimbursements, mapItems, validateQuery } = require("./commonService")
const { getIdFromToken } = require("./jwtService")

const getReimbursement = async (token) => {
    try{
        let id = getIdFromToken(token)
        const [data] = await fileReimbursementRepository.getAll(id)
        let reimbursement = await mapReimbursements(data)
        if(data[0]){
            const [item] = await fileReimbursementRepository.getItems(data[0].flex_reimbursement_id)
            let items = await mapItems(item)
            reimbursement[0].items = items
        }
        return reimbursement
    }
    catch(error){
        return {error: error.message}
    }        
}

module.exports = {
    getReimbursement
}

// const {reimbursementRepository} = require("../repositories/index")
// const { mapReimbursements, mapItems, validateQuery } = require("./commonService")

// const getReimbursement = async () => {
//     try{
//         const [data] = await reimbursementRepository.getAll()
//         return await mapReimbursements(data)
//     }
//     catch(error){
//         return {error: error.message}
//     }        
// }

// const getReimbursementById = async (id) => {
//     try{
//         const [data] = await reimbursementRepository.getById(id)
//         if(!data[0]){
//             return {error: `Reimbursement with Id of (${id}) doesn't exist in the current cutoff`}
//         }        
//         let reimbursement = await mapReimbursements(data)
//         const [item] = await reimbursementRepository.getItems(id)
//         let items = await mapItems(item)
//         reimbursement[0].items = items
//         return reimbursement
//     }
//     catch(error){
//         return {error: error.message}
//     }        
// }

// const getReimbursementFilter = async (query) => {
//     try{
//         let parameters = ["emp_num", "first_name", "last_name"]
//         let validate = await validateQuery(Object.keys(query), parameters)
//         if(validate.length > 0){
//             return {error: `'[${validate}]' is not a valid search parameter/s`} 
//         }
//         if(query.emp_num || query.first_name || query.last_name){
//             const [data] = await reimbursementRepository.getFilter(query)
//             let reimbursement = await mapReimbursements(data)
//             reimbursement = await Promise.all(reimbursement.map(async (o) => ({...o, items: (await reimbursementRepository.getItems(o.flex_reimbursement_id))[0]})))
//             return reimbursement 
//         }       
//         return []
//     }
//     catch(error){
//         return {error: error.message}
//     }        
// }

// const updateReimbursement = async (id, body) => {
//     let parametersKeys = ["action"]
//     let parametersValues = ["approved", "rejected"]
//     let parameterStatus = ["rejected", "submitted", "draft"]
//     try{
//         const [data] = await reimbursementRepository.getById(id)
//         if(!data[0]){
//             return {error: `Reimbursement with Id of (${id})  doesn't exist in the current cutoff`}
//         }
//         let validateKeys = await validateQuery(Object.keys(body), parametersKeys)
//         if(validateKeys.length > 0){
//             return {error: `'[${validateKeys}]' is not a valid key parameter/s`} 
//         }
//         let validateValues = await validateQuery(Object.values(body), parametersValues)
//         if(validateValues.length > 0){
//             return {error: `'[${validateValues}]' is not a valid value parameter/s`} 
//         }
//         let status = data[0].status.toLowerCase()
//         let validateStatus = await validateQuery([status], parameterStatus)
//         if(validateStatus.length > 0){
//             return {error: `'Reimbursement with Id of (${id}) is already '${status}', changes are not allowed`} 
//         }
//         return await reimbursementRepository.updateById(id,body.action.toLowerCase())
//     }
//     catch(error){
//         return {error: error.message}
//     }        
// }

// module.exports = {
//     getReimbursement,
//     getReimbursementById,
//     getReimbursementFilter,
//     updateReimbursement
// }