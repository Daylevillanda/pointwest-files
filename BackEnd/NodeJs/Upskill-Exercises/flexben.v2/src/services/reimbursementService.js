const {reimbursementRepository} = require("../repositories/index")

const mapReimbursements = async (reimbursements) => {
    return reimbursements.map((o) => ({ 
        flex_reimbursement_id: o.flex_reimbursement_id,
        transaction_number: o.transaction_number,
        employee_number: o.employee_number,
        total_reimbursement_amount: o.total_reimbursement_amount,
        employee_name: o.lastname+", "+o.firstname,
        date_submitted: o.date_submitted,
        status: o.status
    }))
}

const mapItems = async (items) => {
    return items.map((o) => ({ 
        flex_reimbursement_detail_id: o.flex_reimbursement_detail_id,
        date_added: o.date_added,
        or_number: o.or_number,
        name_of_establishment: o.name_of_establishment,
        tin_of_establishment: o.tin_of_establishment,
        amount: o.amount,
        category_id: o.category_id
    }))
}

const getReimbursement = async () => {
    try{
        const [data] = await reimbursementRepository.getAll()
        let reimbursement = await mapReimbursements(data)
        return reimbursement
    }
    catch(error){
        return {error: error.message}
    }        
}

const getReimbursementById = async (id) => {
    try{
        const [data] = await reimbursementRepository.getById(id)
        if(!data[0]){
            return {error: "Reimbursement doesn't exist in the current cutoff"}
        }        
        let reimbursement = await mapReimbursements(data)
        const [item] = await reimbursementRepository.getItems(id)
        let items = await mapItems(item)
        reimbursement[0].items = items
        return reimbursement
    }
    catch(error){
        return {error: error.message}
    }        
}

const getReimbursementFilter = async (query) => {
    try{
        let searchParameters = ["emp_num", "first_name", "last_name"]
        for(let i in query){
            if(!searchParameters.includes(i))
                return {error: `'${i}' is not a valid search parameter`}            
        }
        if(query.emp_num || query.first_name || query.last_name){
            const [data] = await reimbursementRepository.getFilter(query)
            let reimbursement = await mapReimbursements(data)
            reimbursement = await Promise.all(reimbursement.map(async (o) => ({...o, items: (await reimbursementRepository.getItems(o.flex_reimbursement_id))[0]})))
            return reimbursement 
        }       
        return []
    }
    catch(error){
        return {error: error.message}
    }        
}

module.exports = {
    getReimbursement,
    getReimbursementById,
    getReimbursementFilter
}