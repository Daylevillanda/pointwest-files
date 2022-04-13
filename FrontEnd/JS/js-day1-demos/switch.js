function greet(language) {
  switch (language) {
    case 'en':
      return 'hello';
    case 'jp':
      return 'こんにちは';
    case 'kr':
      return '안녕하세요';
    default:
      return 'Please select a language';
  }
}

let greeting1 = greet('en');
console.log(greeting1);

let greeting2 = greet('jp');
console.log(greeting2);

let greeting3 = greet('kr');
console.log(greeting3);

let greeting4 = greet('tl');
console.log(greeting4);