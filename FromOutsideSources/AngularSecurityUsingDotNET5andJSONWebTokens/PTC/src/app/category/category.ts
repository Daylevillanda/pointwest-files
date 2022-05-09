export class Category {
  public constructor(init?: Partial<Category>) {
    Object.assign(this, init);
  }

  categoryId: number = 0;
  categoryName: string = "";
}