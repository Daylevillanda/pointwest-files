import React, { useState } from "react";

export default function AppState() {
    const [isHungry, setIsHungry] = useState(true);
    return {
        isHungry,
        setIsHungry
    }
}