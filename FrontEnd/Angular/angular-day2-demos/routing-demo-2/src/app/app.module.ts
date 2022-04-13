import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { FooterComponent } from './footer/footer.component';
import { HomePageComponent } from './home-page/home-page.component';
import { AboutPageComponent } from './about-page/about-page.component';
import { ProductDetailsPageComponent } from './product-details-page/product-details-page.component';
import { NotFoundPageComponent } from './not-found-page/not-found-page.component';
import { RatingStarsComponent } from './product-details-page/rating-stars/rating-stars.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    FooterComponent,
    HomePageComponent,
    AboutPageComponent,
    ProductDetailsPageComponent,
    NotFoundPageComponent,
    RatingStarsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
