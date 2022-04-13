import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HelloWorldComponent } from './hello-world/hello-world.component';
import { ChildComponent } from './hello-world/child/child.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    HelloWorldComponent,
    ChildComponent
  ],
  imports: [
    BrowserModule,
    FormsModule  // to use ngModel
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
