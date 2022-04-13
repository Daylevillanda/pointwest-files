import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { ICart } from './models/carts';
import { IProducts, IReview } from './models/products';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  carts$ = new BehaviorSubject<ICart[]>([]);

  getTotalCart(): number {
    let totalQuantity = 0;
    let carts = this.carts$.value;
    for (let cart of carts) {
      totalQuantity += cart.productTotalQuantity;
    }
    return totalQuantity;
  }

  
  addCart(cart: ICart): void {
    let carts = this.carts$.value;
    carts.push(cart);
    this.carts$.next(carts);
  }

  updateCart(index: number, cart: ICart): void {
    let carts = this.carts$.value;
    carts[index] = cart;
    this.carts$.next(carts);
  }

  deleteCart(index: number): void {
    let carts = this.carts$.value;
    carts.splice(index,1);
    this.carts$.next(carts);
  }

  getAveRating(productReview: IReview[]): number{
    let sum = 0;
    for( let review of productReview){
      sum += review.reviewRating;
    }
    return (sum/productReview.length);
  }
  
  getReviewCount(productReview: IReview[]): number{
    return productReview.length;
  }

  createStarArray(rating: number): number[]{
    return new Array(rating).fill(1);
  }

  getProducts(): Observable<IProducts[]> {
    return of([
      {
        productId: 1,
        productPhoto: "../assets/img/sunflower_solo.jpg",
        productName: "Sunflower",
        productPrice: 900,
        productDescription: "Cheap sunflower turned expensive because it was formerly owned by a renowned singer Ariana Grande",
        productReview:[{
          reviewUserName:"justyneNew09",
          reviewDate:"21 Dec 2021",
          reviewContent:"This is really good. Like legit Item.",
          reviewRating: 5
        },
        {
          reviewUserName:"mochi-mochi",
          reviewDate:"20 Dec 2021",
          reviewContent:"Not that good, I have seen something better than this but cheaper",
          reviewRating: 2
        }]
      },
      {
        productId: 2,
        productPhoto: "../assets/img/sunflower_triplets.jpg",
        productName: "Sunflower Triplets",
        productPrice: 1300,
        productDescription: "Amazing sun flower!. triplets. triple the flower, triple the beauty",
        productReview:[{
          reviewUserName:"ghijini",
          reviewDate:"12 Nov 2021",
          reviewContent:"WOW! This is so beautiful. Tho it is expensive",
          reviewRating:5
        },
        {
          reviewUserName:"Vincentt10",
          reviewDate:"11 Nov 2021",
          reviewContent:"Beautiful three flowers",
          reviewRating: 5
        },
        {
          reviewUserName:"PrettyBabe",
          reviewDate:"10 Nov 2021",
          reviewContent:"Nice",
          reviewRating: 5
        }]
      },
      {
        productId: 3,
        productPhoto: "../assets/img/red_rose.jpeg",
        productName: " Red France Rose",
        productPrice: 1000,
        productDescription: "Blessed with a vibrant, scarlet color, the Red France rose variety is the perfect red rose to say “I Love You”. Each bloom of these red roses usually measures between 8 - 12.5 cm wide, with a long, straight stem that grows as tall as 1.3 m.",
        productReview:[
        {
          reviewUserName:"aNgel",
          reviewDate:"29 Aug 2021",
          reviewContent:"So beautiful. Definitely worth the buy.",
          reviewRating: 5},
        {
          reviewUserName:"coolKid01",
          reviewDate:" 21 Jul 2021",
          reviewContent:"Really love the plant. Will surely buy again.",
          reviewRating: 5},
        {
          reviewUserName:"JanDoe09",
          reviewDate:"04 Jul 2021",
          reviewContent:"Too expensive for the quality..",
          reviewRating: 2}]
      },
      {
        productId: 4,
        productPhoto: "../assets/img/lavender_rose.png",
        productName: "Cool Water Rose",
        productPrice: 1100,        
        productDescription: "Enchanting and elegant best describe these lavender roses. This rare flower has  a large head that opens nicely with plenty of petals with not much fragrance. The Cool Water rose pairs well with the other purples, like Dark Purple Stock and Purple Mini Callas to create a lush purple design.",
        productReview:[
        {
          reviewUserName:"V3rm0uTh",
          reviewDate:"15 Sept 2021",
          reviewContent:" Looks very classy. Perfect gift!!",
          reviewRating: 5},

        {
          reviewUserName:"bouRb0n00",
          reviewDate:"11 Aug 2021",
          reviewContent:" The best!",
          reviewRating: 5},

        {
          reviewUserName:"Rye44",
          reviewDate:"10 Aug 2021",
          reviewContent:" It was okay.",
          reviewRating: 3}]
      },
      {
        productId: 5,
        productPhoto: "../assets/img/white_rose.jpeg",
        productName: "White Rose",
        productPrice: 900,        
        productDescription: "The white rose is the most versatile color. This flower is able to convey romance, appreciation, compassion and purity. The white rose is also called the bridal rose and as such represents unity, and new bonds of love.",
        productReview:[
        {
          reviewUserName:"Ginwyt88",
          reviewDate:"30 Sept 2021",
          reviewContent:" Looks cheap compared to its price",
          reviewRating: 2},

        {
          reviewUserName:"Vudkah",
          reviewDate:"10 Sept 2021",
          reviewContent:" disappointing!",
          reviewRating: 1}]
      },
      {
        productId: 6,
        productPhoto: "../assets/img/jade.jpeg",
        productName: "Jade Plant",
        productPrice: 500,        
        productDescription: "The jade plant is sometimes called as money tree or lucky plant, believed to bring good fortune to its owner. This succulent plant bears small, thick leaves in rich, jade color, hence the name. Occasionally, it bears small flowers in either pink or white color, adding to its already beautiful look. The jade plant is commonly planted in decorative pots as bonsai to adorn indoor and covered spaces of the home.",
        productReview:[
        {
          reviewUserName:"h0lmesss",
          reviewDate:"30 Aug 2021",
          reviewContent:" Wow. Amazing.. Thank you seller!",
          reviewRating: 5},

        {
          reviewUserName:"ruSsell",
          reviewDate:"25 Aug 2021",
          reviewContent:" Delivered earlier than expected. So happy..",
          reviewRating: 4},

        {
          reviewUserName:"neeAdleR",
          reviewDate:"15 Jul 2021",
          reviewContent:"  Wonderful plant! Kudos!!!!!!!",
          reviewRating: 5}]
      },
      {
        productId: 7,
        productPhoto: "../assets/img/hens_&_chicks.jpeg",
        productName: "Hens-and-chicks Succulent",
        productPrice: 400,        
        productDescription: "Hens-and-chicks plants consist of small succulents that bear flowers, with leaves that form rosettes (hen) and grow offsets around them (chicks). They are quite easy to propagate because you only need to transplant the offsets that have roots of their own for them to become mature plants (hen). They thrive potted or directly on a fertile, rocky soil with lots of sun and occasional shade, but rot easily with too much moisture.",
        productReview:[
        {
          reviewUserName:"Nina",
          reviewDate:"24 Oct 2021",
          reviewContent:" very good condition when it arrived. Probably will order again",
          reviewRating: 4},

        {
          reviewUserName:"Eddi33",
          reviewDate:"12 Sept 2021",
          reviewContent:" My mom loved it. Thank you",
          reviewRating: 5}]
      },
      {
        productId: 8,
        productPhoto: "../assets/img/bunny_ears_cactus.jpeg",
        productName: "Bunny Ears Cactus",
        productPrice: 300,        
        productDescription: "Opuntia is the genus of the cactus plants that feature flat, oval shaped shoots with spines (spineless varieties are also available) and often bears large, edible fruit (prickly pear or tuna). Although harvesting pads and fruits is quite tricky (must be done by hand), propagating it is very easy. Bunny ears cactus plants grow very quickly after a pad is transplanted to more than 6 feet tall with pads growing in different directions.",
        productReview:[
        {
          reviewUserName:"gRayson",
          reviewDate:"27 Jul 2021",
          reviewContent:" Good buy",
          reviewRating: 3},

        {
          reviewUserName:"seiChan",
          reviewDate:"20 Jul 2021",
          reviewContent:" Impressed with the packaging, highly recommended.",
          reviewRating: 4}]
      },
      {
        productId: 9,
        productPhoto: "../assets/img/ball_cactus.jpeg",
        productName: "Ball Cactus",
        productPrice: 450,        
        productDescription: "The ball cactus refers to a range of cactus with ball-like apexes including the common ball cactus, moon cactus, golden ball cactus, balloon cactus, silver ball cactus and mountain ball cactus. Ball cactus varieties can grow as small as a couple of inches to about 2 feet tall, with funnel-shaped flowers in attractive colors at its apex.",
        productReview:[
        {
          reviewUserName:"Crowe",
          reviewDate:"19 Sept 2021",
          reviewContent:" Super legit. Super love it.",
          reviewRating: 5},

        {
          reviewUserName:"LisaStar",
          reviewDate:"23 Aug 2021",
          reviewContent:" beautiful..",
          reviewRating: 5},
        {
          reviewUserName:"koWalskiz55",
          reviewDate:"14 Aug 2021",
          reviewContent:" delivered the wrong order.",
          reviewRating: 1}]
      },
      {
        productId: 10,
        productPhoto: "../assets/img/agave.jpeg",
        productName: "Agave",
        productPrice: 500,        
        productDescription: "Agave is a succulent that looks like giant aloe vera with flowers that spike out up to four times taller than the leaves. Other than being ornamental plants, agave is also cultivated for use in the production of tequila and agave syrup. Suckers that grow at the base are removed and transplanted to become new plants.",
        productReview:[
        {
          reviewUserName:"JackSigl3r",
          reviewDate:"14 Oct 2021",
          reviewContent:" glad I found this..",
          reviewRating: 4},

        {
          reviewUserName:"zelDaB",
          reviewDate:"28 Sept 2021",
          reviewContent:" added this to my garden. tnx!!",
          reviewRating: 5},
        {
          reviewUserName:"StanTrem",
          reviewDate:"15 Sept 2021",
          reviewContent:" seller was very responsive. Good job!",
          reviewRating: 5}]
      }
    ])
  }
}