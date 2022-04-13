import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CustomModule } from './custom/custom.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    CustomModule // import our custom module
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
