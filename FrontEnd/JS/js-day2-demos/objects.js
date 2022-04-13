let person = {
  firstName: 'JM',
  lastName: 'Flores',
  age: 21,
  address: {
    street: 'Maginhawa St',
    barangay: 'UP Village',
    district: 'Diliman',
    city: 'Quezon City'
  }
};

console.log(person);
console.log(person.firstName);
console.log(person.age);
console.log(person.address.barangay);

console.log(Object.keys(person));
console.log(Object.values(person));

person.firstName = 'JM Pogi';
person.address.street = 'Mapagmahal St';
console.log('updated person:', person);