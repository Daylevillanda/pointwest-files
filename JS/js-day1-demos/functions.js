function cube(num) {
  return num ** 3;
}

// num => num ** 3;

function getVolume(radius) {
  let volume = (4 / 3) * Math.PI * cube(radius);
  return volume;
}

let sphereVol = getVolume(7);
console.log(sphereVol);

setTimeout(() => {
  console.log('Done!');
}, 1000);