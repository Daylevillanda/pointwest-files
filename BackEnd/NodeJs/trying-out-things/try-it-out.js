let array1 = [{ id: 1, name: 'milla' }, { id: 2, name: 'alice' }];
let array2 = [{ id: 3, name: 'bobba', height: '170cm', age: 22 }, { id: 2, name: 'alice', height: '169cm', age: 21 }, { id: 1, name: 'milla', height: '171cm', age: 24 }, { id: 4, name: 'ricky', height: '168cm', age: 32 }];

let idMap = array1.reduce((res, curr) => (res[curr.id] = true, res), {});
console.log(idMap)
let filtered = array2.filter((item) => idMap[item.id]);

console.log(filtered)