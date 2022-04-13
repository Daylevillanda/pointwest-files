function greet(language) {
  if (language == 'en') {
    return 'hello';
  } else if (language == 'jp') {
    return 'こんにちは';
  } else if (language == 'kr') {
    return '안녕하세요';
  } else {
    return 'Please select a language.';
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