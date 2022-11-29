import React, { useState } from "react";

export default function AppState() {
    const [isLoggedIn, setisLoggedIn] = useState(true);
    return {
        isLoggedIn,
        setisLoggedIn
    }
}