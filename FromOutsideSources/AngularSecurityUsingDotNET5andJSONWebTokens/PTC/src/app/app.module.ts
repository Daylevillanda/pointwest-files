import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductListComponent } from './product/product-list.component';
import { ProductDetailComponent } from './product/product-detail.component';
import { CategoryListComponent } from './category/category-list.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PageNotFoundComponent } from './public/page-not-found.component';
import { InfoMessageComponent } from './shared/messaging/info-message.component';
import { ExceptionMessageComponent } from './shared/messaging/exception-message.component';
import { ValidationMessageComponent } from './shared/messaging/validation-message.component';
import { LogMaintenanceComponent } from './shared/logging/log-maintenance.component';
import { ConfigurationComponent } from './shared/configuration/configuration.component';
import { LoginComponent } from './public/login.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,
    ProductDetailComponent,
    CategoryListComponent,
    DashboardComponent,
    PageNotFoundComponent,
    InfoMessageComponent,
    ExceptionMessageComponent,
    ValidationMessageComponent,
    LogMaintenanceComponent,
    ConfigurationComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
