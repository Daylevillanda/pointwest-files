const rights = {
    "1": [
        "STAFF",
        "SHOW_FILM", "CREATE_FILM", "EDIT_FILM", "DELETE_FILM",
        "SHOW_ACTOR", "CREATE_ACTOR", "EDIT_ACTOR", "DELETE_ACTOR",
        "SHOW_CUSTOMER"
    ],
    "2": [
        "SHOW_CUSTOMER"
    ]
}

exports.getAccessRights = (id) => {
    return rights[id]
}