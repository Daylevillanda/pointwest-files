function greet(language) {
  let greeting;

  switch (language) {
    case 'en':
      greeting = 'hello';
      break;
    case 'en':
      greeting = 'hi';
      break;
  }

  return greeting;
}

console.log(greet('en'));