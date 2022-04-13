module.exports = function area(radius) {
  if (isNaN(parseFloat(radius))) {
    throw new Error('Invalid input');
  }

  return Math.PI * radius ** 2;
}