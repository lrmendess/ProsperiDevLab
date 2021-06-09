import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Customer } from 'src/app/models/customer.model';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-create-customer-form-dialog',
  templateUrl: './create-customer-form-dialog.component.html',
  styleUrls: ['./create-customer-form-dialog.component.scss']
})
export class CreateCustomerFormDialogComponent implements OnInit {

  customer: Customer = { } as Customer;
  
  errors: any = {};

  constructor(
    @Inject(MAT_DIALOG_DATA) public _customer: Customer,
    private _dialogRef: MatDialogRef<CreateCustomerFormDialogComponent>,
    private _snackBar: MatSnackBar,
    private _customerService: CustomerService) { }

  ngOnInit(): void {
    if (this._customer) {
      this.customer = { ...this._customer };
    }
  }

  onSubmit(): void {
    this.errors = {};

    if (this._customer) {
      this._customerService
        .update(this._customer.id!, this.customer)
        .subscribe(
          success => {
            this._dialogRef.close({ data: success });
          },
          fail => {
            this.errors = fail.error;
            this.showSnackBarErrors();
          }
        );
    } else {
      this._customerService
        .create(this.customer)
        .subscribe(
          success => {
            this._dialogRef.close({ data: success });
          },
          fail => {
            this.errors = fail.error;
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

}
