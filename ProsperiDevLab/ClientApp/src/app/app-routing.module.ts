import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerListComponent } from './components/Customer/customer-list/customer-list.component';
import { EmployeeListComponent } from './components/Employee/employee-list/employee-list.component';
import { ServiceOrderListComponent } from './components/ServiceOrder/service-order-list/service-order-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'service-orders', pathMatch: 'full' },
  { path: 'service-orders', component: ServiceOrderListComponent },
  { path: 'employees', component: EmployeeListComponent },
  { path: 'customers', component: CustomerListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
