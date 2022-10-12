const rights = {
    "1": [
        "EMPLOYEE"
    ],
    "2": [
        "HR"
    ]
}

exports.getAccessRights = (id) => {
    return rights[id]
}