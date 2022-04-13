interface Shape {
  area(): number;
}

class Rectangle implements Shape {
  width: number;
  height: number;

  constructor(width: number, height: number) {
    this.width = width;
    this.height = height;
  }

  area() {
    return this.width * this.height;
  }
}

class Hexagon implements Shape {
  side: number;

  constructor(side: number) {
    this.side = side;
  }

  area() {
    return ((3 * Math.sqrt(3)) / 2) * this.side ** 2;
  }
}

class Prism {
  base: Shape;
  length: number;

  constructor(base: Shape, length: number) {
    this.base = base;
    this.length = length;
  }

  volume() {
    return this.base.area() * this.length;
  }
}

class RectangularPrism extends Prism {
  constructor(width: number, height: number, length: number) {
    super(new Rectangle(width, height), length);
  }
}

class HexagonalPrism extends Prism {
  constructor(side: number, length: number) {
    super(new Hexagon(side), length);
  }
}

let kahon = new RectangularPrism(2, 3, 4);
let creamo = new HexagonalPrism(3, 4);