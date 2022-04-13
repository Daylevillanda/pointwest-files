function printStars(num) {
  for (let i = 1; i <= num; i++) {
    console.log('*'.repeat(i));
  }
}

function printDollars(num) {
  let i = 1;
  while (i <= num) {
    console.log('$'.repeat(i));
    i++;
  }
}

function demoDoWhile() {
  do {
    console.log('do while ran');
  } while (false);
}

printStars(5);
printDollars(5);
demoDoWhile();