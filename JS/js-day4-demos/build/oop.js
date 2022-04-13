"use strict";
class Circle {
    constructor(radius) {
        this.radius = radius;
    }
    area() {
        return Math.PI * this.radius ** 2;
    }
}
class Rectangle2 {
    constructor(width, height) {
        this.width = width;
        this.height = height;
    }
    area() {
        return this.width * this.height;
    }
}
class Triangle {
    constructor(base, height) {
        this.base = base;
        this.height = height;
    }
    area() {
        return (this.base * this.height) / 2;
    }
    static getName() {
        return 'Triangle';
    }
}
function getArea(shape) {
    return `The area is ${shape.area()}`;
}
let myObj = { radius: 8 };
let bilog = new Circle(myObj.radius);
getArea(bilog);
let triangle = new Triangle(2, 3);
function createTriangle() {
    let rawBase = document.querySelector('inpt[name=base]').value;
    let base = parseFloat(rawBase);
}
