import { IProducts } from "./products";

export interface ICart {
    cartId: number;
    cartProductQuantity: number;
    cartProductPrice: number;
    products: IProducts;
}
