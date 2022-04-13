"use strict";
class Rectangle {
    constructor(width, height) {
        this.width = width;
        this.height = height;
    }
    area() {
        return this.width * this.height;
    }
}
class Hexagon {
    constructor(side) {
        this.side = side;
    }
    area() {
        return ((3 * Math.sqrt(3)) / 2) * this.side ** 2;
    }
}
class Prism {
    constructor(base, length) {
        this.base = base;
        this.length = length;
    }
    volume() {
        return this.base.area() * this.length;
    }
}
class RectangularPrism extends Prism {
    constructor(width, height, length) {
        super(new Rectangle(width, height), length);
    }
}
class HexagonalPrism extends Prism {
    constructor(side, length) {
        super(new Hexagon(side), length);
    }
}
let kahon = new RectangularPrism(2, 3, 4);
let creamo = new HexagonalPrism(3, 4);
