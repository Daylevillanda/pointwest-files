exports.mapReimbursements = async (reimbursements) => {
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

exports.mapItems = async (items) => {
    return items.map((o) => ({ 
        flex_reimbursement_detail_id: o.flex_reimbursement_detail_id,
        date_added: o.date_added,
        or_number: o.or_number,
        name_of_establishment: o.name_of_establishment,
        tin_of_establishment: o.tin_of_establishment,
        amount: o.amount,
        category_id: o.category_id,
        status: o.status
    }))
}

exports.validateQuery = async (query, parameter) => {
    return query.filter((a)=>!parameter.includes(a.toLowerCase()))
}

exports.validateExistQuery = async (query, parameter) => {
    return query.filter((a)=>parameter.includes(a.toLowerCase()))
}