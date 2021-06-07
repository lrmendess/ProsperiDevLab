import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ServiceOrderListComponent } from './components/ServiceOrder/service-order-list/service-order-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'service-orders', pathMatch: 'full' },
  { path: 'service-orders', component: ServiceOrderListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
