import Shape, {shapeName} from './shape';

export class Rectangle implements Shape {
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