interface Shape {
  area(): number;
}

class Circle implements Shape {
  radius: number;

  constructor(radius: number) {
    this.radius = radius;
  }

  area() {
    return Math.PI * this.radius ** 2;
  }
}

class Rectangle2 implements Shape {
  constructor(
    public width: number,
    public height: number
  ) {
  }

  area() {
    return this.width * this.height;
  }
}

class Triangle implements Shape {
  constructor(public base: number, public height: number) {
  }

  area() {
    return (this.base * this.height) / 2;
  }

  static getName() {
    return 'Triangle';
  }
}

function getArea(shape: Shape) {
  return `The area is ${shape.area()}`;
}

let myObj = {radius: 8};
let bilog = new Circle(myObj.radius);
getArea(bilog);

let triangle = new Triangle(2, 3);

function createTriangle() {
  let rawBase = (document.querySelector('inpt[name=base]') as HTMLInputElement).value;
  let base = parseFloat(rawBase);
}