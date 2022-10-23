const { fileReimbursementRepository, cutoffRepository } = require("../repositories/index")
const { mapReimbursements, mapItems, validateQuery, validateExistQuery } = require("./commonService")
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

const addReimbursement = async (token, values) => {
    try{
        let id = getIdFromToken(token)        
        let parameters = ["date", "or", "establishment", "tin_establishment", "amount", "category_id"]
        let minimumAmount = 500
        let dateNow = new Date(Date.now())
        let reimbursementId = 0

        const [cutoff] = await cutoffRepository.getCutoff()
        if(!cutoff[0]){
            return {error: "No active flex cycle cutoff"}
        }
        let validateValues = await validateQuery(Object.keys(values), parameters)
        if(validateValues.length > 0){
            return {error: `'[${validateValues}]' is not a valid input parameter/s`} 
        }
        let checkMissingValues = await validateQuery(parameters, Object.keys(values))
        if(checkMissingValues.length > 0){
            return {error: `Missing input parameters '[${checkMissingValues}]'`} 
        }
        if(values.amount < minimumAmount){
            return {error: `Minimum Amount per request is PHP${minimumAmount}`} 
        }
        if(values.amount > cutoff[0]?.cut_off_cap_amount){
        }
        let dateGiven = new Date(values.date) 
        if(dateGiven > dateNow){
        }
        if(dateGiven.getFullYear() != dateNow.getFullYear()){
            return {error: `Invalid Year`} 
        }        
        let cutoffStartDate = new Date(cutoff[0].start_date) 
        let cutoffEndDate = new Date(cutoff[0].end_date)
        if(dateGiven < cutoffStartDate || dateGiven > cutoffEndDate) {
            return {error: `Date is not within the cutoff date`} 
        }
        let [data] = await fileReimbursementRepository.getAll(id)
        if(!data[0]){
            let [reimbursement] = await fileReimbursementRepository.createReimbursement([id,cutoff[0].flex_cutoff_id,values.amount])
            reimbursementId = reimbursement.insertId
            const [created] = await fileReimbursementRepository.getAll(id)
            data = created
        }
        else {
            reimbursementId = data[0].flex_reimbursement_id
            let total = data[0].total_reimbursement_amount + values.amount
            await fileReimbursementRepository.updateReimbursement(reimbursementId,{total_reimbursement_amount: total})
            const [existing] = await fileReimbursementRepository.getAll(id)
            data = existing
        }
        
        await fileReimbursementRepository.createItem([
            reimbursementId,
            values.or,
            values.establishment,
            values.tin_establishment,
            values.amount,
            values.category_id,
            dateGiven
        ])

        let reimbursement = await mapReimbursements(data)
        const [item] = await fileReimbursementRepository.getItems(data[0].flex_reimbursement_id)
        let items = await mapItems(item)
        reimbursement[0].items = items
        return reimbursement
    }
    catch(error){
        return {error: error.message}
    }        
}

module.exports = {
    getReimbursement,
    addReimbursement
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