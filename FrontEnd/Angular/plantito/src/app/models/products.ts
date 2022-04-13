export interface IProducts {
    productId: number;
    productPhoto: string;
    productName: string;
    productPrice: number;
    productDescription: string;
    productReview: IReview[]
}

export interface IReview {
    reviewUserName: string,
    reviewDate: string,
    reviewContent: string,
    reviewRating: number
}

