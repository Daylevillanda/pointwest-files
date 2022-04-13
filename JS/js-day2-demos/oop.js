class Rectangle {
  constructor(length, width) {
    this.length = length;
    this.width = width;
  }

  perimeter() {
    return this.length * 2 + this.width * 2;
  }

  area() {
    return this.length * this.width;
  }
}

let kuwadrado = new Rectangle(7, 3);
console.log('rectangle');
console.log('length:', kuwadrado.length);
console.log('area:', kuwadrado.area());

class Square extends Rectangle {
  constructor(sideLength) {
    super(sideLength, sideLength);
  }
}

let square1 = new Square(5);
console.log('square');
console.log('width:', square1.width);
console.log('length:', square1.length);
console.log('perimeter:', square1.perimeter());
console.log('area:', square1.area());

class Car {
  drive() {
    this.#startEngine();
    this.#setGear(1);
    this.#accelerate();
  }

  #startEngine() {
    console.log('engine started');
  }

  #setGear(gear) {
    console.log('gear set to', gear);
  }

  #accelerate() {
    console.log('vroom vroom');
  }
}

let tsikot = new Car();
tsikot.drive();