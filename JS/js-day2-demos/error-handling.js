let notAFunction = 'abc';

function toNumber(string) {
  let result = parseFloat(string);
  if (!isNaN(result)) {
    return result;
  } else {
    throw new Error('The value you entered is not a number');
  }
}

try {
  // thisFunctionDoesNotExist();
  console.log(toNumber('one'));
  console.log('run this afterwards');
} catch (error) {
  if (error instanceof ReferenceError) {
    console.log('Function does not exist!!!!!!');
  } else {
    console.log('Something happened:', error.message);
  }
} finally {
  console.log('finally ariel happened to me');
}