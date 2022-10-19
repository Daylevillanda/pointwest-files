const {userRepository} = require("../repositories/index")

const validateCredential = async (credentials) => {
    if(credentials.email && credentials.password){
        try{
            const [user] = await userRepository.getUser(credentials)
            if(!user[0]){
                return {
                    error: "Incorrect credentials"
                }
            }
            let result = user.map(
                (o) => ({ 
                    employee_id: o.employee_id,
                    email: o.email,
                    firstname: o.firstname,
                    lastname: o.lastname,
                    role_id: o.role_id
                })
            )
            return result[0]
        }
        catch(error){
            return {error: error.message}
        }        
    }
    return {error: "Missing Email/Password"}
}

module.exports = {
    validateCredential
}