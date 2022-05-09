export class Product {
  public constructor(init?: Partial<Product>) {
    Object.assign(this, init);
  }

  productId: number = 0;
  productName: string = "";
  introductionDate: Date = new Date();
  price: number = 0;
  url: string = "";
  categoryId: number = 0;
}
