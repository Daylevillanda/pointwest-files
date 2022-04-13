export interface IProducts {
    productPhoto: string;
    productName: string;
    productPrice: number;
    productReview: IReview[]
}

export interface IReview {
    reviewUserName: string,
    reviewDate: string,
    reviewContent: string,
    reviewRating: number
}

