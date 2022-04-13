function convertTemperature(num, temp) {    
    switch (temp) {
        case 'c':
            let c = (num - 32) / 1.8;
            return num + ` Fahrenheit equals ` + c + ` Celsius`;
            break;
        case 'f':
            let f = (num * 1.8) + 32;
            return num + ` Celsius equals ` + f + ` Fahrenheit`;
            break;
        default:
            return 'Invalid temperature unit';
    }
}

// console.log(convertTemperature(32,'b'))

function factorial(num) {
    if (num === 0){
        return '0! equals 1';
    }
    else if (num <= -1) {
        return `Invalid input`;
    }
    else {
        let output = 1;
        for (let i = num; i > 0; i--){            
            output *= i;
        }
        return num + `! equals ` + output;
    }
}

// console.log(factorial(0))
// console.log(factorial(-1))
// console.log(factorial(5))