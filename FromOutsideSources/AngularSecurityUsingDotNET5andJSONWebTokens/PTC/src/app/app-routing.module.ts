import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from "./product/product-list.component";
import { CategoryListComponent } from './category/category-list.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { PageNotFoundComponent } from './public/page-not-found.component';
import { ProductDetailComponent } from './product/product-detail.component';
import { ValidIdGuard } from './shared/guards/valid-id.guard';
import { NotSavedGuard } from './shared/guards/not-saved.guard';
import { LogMaintenanceComponent } from './shared/logging/log-maintenance.component';
import { ConfigurationComponent } from './shared/configuration/configuration.component';

const routes: Routes = [
  {
    path: 'dashboard',
    component: DashboardComponent
  },
  {
    path: 'categories',
    component: CategoryListComponent
  },
  {
    path: 'settings',
    component: ConfigurationComponent
  },
  {
    path: 'logmaintenance',
    component: LogMaintenanceComponent
  },
  {
    path: 'products',
    component: ProductListComponent
  },
  {
    path: 'productDetail/:id',
    canActivate: [ValidIdGuard],
    canDeactivate: [NotSavedGuard],
    data: { redirectTo: 'products' },
    component: ProductDetailComponent
  },
  {
    path: '', redirectTo: 'dashboard', pathMatch: 'full'
  },
  {
    path: '**', component: PageNotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
