import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Currency } from 'src/app/models/currency.model';
import { Customer } from 'src/app/models/customer.model';
import { Employee } from 'src/app/models/employee.model';
import { Price } from 'src/app/models/price.model';
import { ServiceOrder } from 'src/app/models/service-order.model';
import { CurrencyService } from 'src/app/services/currency.service';
import { CustomerService } from 'src/app/services/customer.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { ServiceOrderService } from 'src/app/services/service-order.service';

@Component({
  selector: 'app-create-service-order-form-dialog',
  templateUrl: './create-service-order-form-dialog.component.html',
  styleUrls: ['./create-service-order-form-dialog.component.scss']
})
export class CreateServiceOrderFormComponentDialog implements OnInit {

  serviceOrder: ServiceOrder = { price: {} as Price } as ServiceOrder;
  
  currencies: Currency[] = [];
  employees:  Employee[] = [];
  customers:  Customer[] = [];

  constructor(
    private _dialogRef: MatDialogRef<CreateServiceOrderFormComponentDialog>,
    private _currencieService: CurrencyService,
    private _employeeService: EmployeeService,
    private _customerService: CustomerService,
    private _serviceOrderService: ServiceOrderService) { }

  ngOnInit(): void {
    this._currencieService.getAll().subscribe(
      response => {
        this.currencies = response;
      },
      error => {
        this.currencies = [];
      }
    );

    this._employeeService.getAll().subscribe(
      response => {
        this.employees = response;
      },
      error => {
        this.employees = [];
      }
    );

    this._customerService.getAll().subscribe(
      response => {
        this.customers = response;
      },
      error => {
        this.customers = [];
      }
    );
  }

  onSubmit(serviceOrder?: ServiceOrder): void {
    console.log(this.serviceOrder);

    // Edit
    if (serviceOrder) {
      this._serviceOrderService
        .update(serviceOrder.id!, serviceOrder)
        .subscribe(
          response => {
            this._dialogRef.close();
          },
          error => {
            console.log(error);
          }
        )
    // Create
    } else {
      this._serviceOrderService
        .create(this.serviceOrder)
        .subscribe(
          response => {
            this._dialogRef.close();
          },
          error => {
            console.log(error);
          }
        );
    }
  }

}
