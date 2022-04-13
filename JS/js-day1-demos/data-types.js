let greeting = 'Hello world!';
let twice = '트와이스';

let greeting2 = `Annyeonghaseyo ${twice} imnida.`;

console.log(greeting);
console.log(twice);
console.log(greeting2);

let num1 = 3;
let num2 = 2.1;
console.log(num1 * num2);

let rosesAreRed = true;
let covidIsOver = false;
console.log(rosesAreRed && covidIsOver);

let thisIsNull = null;
let thisIsUndefined;
console.log('thisIsNull:', thisIsNull);
console.log('thisIsUndefined:', thisIsUndefined);
console.log(thisIsNull === thisIsUndefined);

console.log(2 + '2'); // "22"
console.log('2' + '2'); // "22"
console.log(2 + parseInt('2')); // "22"