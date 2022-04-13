function square(num) {
  num = num * num;
  return num;
}

let y = 2;
let result = square(y);

console.log(result);
console.log(y);


function addItem(arr, item) {
  let newArr = JSON.parse(JSON.stringify(arr));
  newArr.push(item);
  return newArr;
}

let myArr = ['wan', 'tu', 'tri'];
let result2 = addItem(myArr, 'por');
console.log(result2);
console.log(myArr);


function changeName(obj) {
  let newObj = Object.assign({}, obj);
  newObj.firstName = 'Jey Em';
  newObj.lastName = 'Pogi';
  return newObj;
}

let myObj = {
  firstName: 'JM',
  lastName: 'Flores'
};
let result3 = changeName(myObj);
console.log(result3);
console.log(myObj);