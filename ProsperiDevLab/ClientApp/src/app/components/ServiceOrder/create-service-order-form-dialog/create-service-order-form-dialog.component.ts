import { Component, Inject, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

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
export class CreateServiceOrderFormDialogComponent implements OnInit {

  serviceOrder: ServiceOrder = { price: { currency: {} as Currency } as Price } as ServiceOrder;
  
  errors: any = {};

  currencies: Currency[] = [];
  employees:  Employee[] = [];
  customers:  Customer[] = [];

  constructor(
    @Inject(MAT_DIALOG_DATA) public _serviceOrder: ServiceOrder,
    private _dialogRef: MatDialogRef<CreateServiceOrderFormDialogComponent>,
    private _snackBar: MatSnackBar,
    private _currencyService: CurrencyService,
    private _employeeService: EmployeeService,
    private _customerService: CustomerService,
    private _serviceOrderService: ServiceOrderService) { }

  ngOnInit(): void {
    if (this._serviceOrder) {
      this.serviceOrder =           { ...this._serviceOrder           };
      this.serviceOrder.price =     { ...this._serviceOrder.price     };
      this._serviceOrder.customer = { ...this._serviceOrder.customer! };
      this._serviceOrder.employee = { ...this._serviceOrder.employee! };
    }

    this._currencyService.getAll().subscribe(
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

  onSubmit(): void {
    this.errors = {};

    this.serviceOrder.price.value = Number(this.serviceOrder.price.value);
    this.serviceOrder.employeeId = this.serviceOrder.employee?.id!;
    this.serviceOrder.customerId = this.serviceOrder.customer?.id!;

    if (this._serviceOrder) {
      this._serviceOrderService
        .update(this._serviceOrder.id!, this.serviceOrder)
        .subscribe(
          success => {
            this._dialogRef.close({ data: success });
          },
          fail => {
            this.errors = fail.error.Errors;
            this.showSnackBarErrors();
          }
        );
    } else {
      this._serviceOrderService
        .create(this.serviceOrder)
        .subscribe(
          success => {
            this._dialogRef.close({ data: success });
          },
          fail => {
            this.errors = fail.error.Errors;
            this.showSnackBarErrors();
          }
        );
    }
  }

  showSnackBarErrors(): void {
    const snackBarConfig: any = {
      duration: 3000,
      verticalPosition: 'top',
    };

    const emptyErrors = this.errors[''];

    if (emptyErrors) {
      this._snackBar.open(emptyErrors[0], 'OK', snackBarConfig);
    }
  }

  displayEmployeeFn(employee: Employee): string {
    return employee?.name;
  }

  displayCustomerFn(customer: Customer): string {
    return customer?.name;
  }

}
