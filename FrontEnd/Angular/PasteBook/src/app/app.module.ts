import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
// import { FlexLayoutModule } from '@angular/flex-layout';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { CommentComponent } from './post/comment/comment.component';
import { LikeComponent } from './post/like/like.component';
import { RegistrationComponent } from './registration/registration.component';
import { PostComponent } from './post/post.component';
import { LoginComponent } from './login/login.component';
import { UserFriendComponent } from './user-friend/user-friend.component';
import { ViewAlbumComponent } from './album/view-album/view-album.component';
import { AddAlbumComponent } from './album/add-album/add-album.component';
import { UserRegistrationComponent } from './user-registration/user-registration.component';
import { PostdirectoryComponent } from './post/postdirectory/postdirectory.component';
import { SelectedAlbumComponent } from './album/view-album/selected-album/selected-album.component';
import { PhotoComponent } from './album/view-album/selected-album/photo/photo.component';
import { JwtHelperService, JWT_OPTIONS } from '@auth0/angular-jwt';
import { ProfileComponent } from './profile/profile.component';
import { HomePageComponent } from './home-page/home-page.component';
import { NavigationBarComponent } from './navigation-bar/navigation-bar.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    PostComponent,
    CommentComponent,
    LikeComponent,
    PostComponent,
    ViewAlbumComponent,
    AddAlbumComponent,
    UserFriendComponent,
    UserRegistrationComponent,
    LoginComponent,
    UserFriendComponent,
    PostdirectoryComponent,
    SelectedAlbumComponent,
    PhotoComponent,
    RegistrationComponent,
    ProfileComponent,
    HomePageComponent,
    NavigationBarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    // FlexLayoutModule,
    FormsModule
  ],
  providers: [{ provide: JWT_OPTIONS, useValue: JWT_OPTIONS}, JwtHelperService],
  bootstrap: [AppComponent]
})
export class AppModule { }
