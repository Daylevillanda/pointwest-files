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
            return {
                employee_id: user[0]?.employee_id,
                email: user[0]?.email,
                firstname: user[0]?.firstname,
                lastname: user[0]?.lastname,
                role_id: user[0]?.role_id,
            }
        }
        catch(error){
            return {
                error: error.message
            }
        }        
    }
    return {error: "Missing Email/Password"}
}

module.exports = {
    validateCredential
}