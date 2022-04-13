import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { PanganayComponent } from './panganay/panganay.component';
import { BunsoComponent } from './bunso/bunso.component';

@NgModule({
  declarations: [
    AppComponent,
    PanganayComponent,
    BunsoComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
