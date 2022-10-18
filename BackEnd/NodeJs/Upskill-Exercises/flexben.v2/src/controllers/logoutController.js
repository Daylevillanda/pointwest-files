const logout = async (req, res) => {
    res.clearCookie("token");
    res.status(200).json({ 
        "status": 200,
        "statusText": "OK",
        "message": "Logout Successfuly",
    });
};

module.exports = {
    logout
}