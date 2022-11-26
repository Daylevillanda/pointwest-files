import React, { useState } from "react";

import AppNavigation from "../AppNavigation/AppNavigation";

export default function AppState() {
    const [isHungry, setIsHungry] = useState(true);   
    
    const AppState = {
        isHungry,
        setIsHungry
    }

    return <AppNavigation AppState={AppState}/>
}