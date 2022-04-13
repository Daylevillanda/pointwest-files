let twiceMembers = [
  'Tzuyu',
  'Sana',
  'Mina',
  'Jihyo',
  'Dahyun',
  'Chaeyoung'
];
let emptyArray = [];

console.log('4th item:', twiceMembers[4]);

console.log('contents:', twiceMembers);
twiceMembers.push('Nancy');
console.log('contents after push:', twiceMembers);
twiceMembers.unshift('Ningning');
console.log('contents after unshift:', twiceMembers);
twiceMembers.pop();
console.log('contents after pop:', twiceMembers);
twiceMembers.shift();
console.log('contents after shift:', twiceMembers);
twiceMembers.splice(3, 1);
console.log('contents after splice:', twiceMembers);

let array1 = [1, 2, 3];
let array2 = [4, 5, 6];
console.log('concat:', array1.concat(array2));

// for (let i = 0; i < twiceMembers.length; i++) {
//   console.log(twiceMembers[i]);
// }

console.log('Using for loop:');
for (let member of twiceMembers) {
  console.log(member);
}

let mappedArray = twiceMembers.map((item, i) => {
  return i + ': ' + item.toUpperCase() + ' imnida';
});
console.log(mappedArray);

let numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
let evenNumbers = numbers.filter((item) => {
  return item % 2 == 0;
});
console.log(evenNumbers);

console.log('index of chaeyoung:', twiceMembers.indexOf('Chaeyoung'));