import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Customer } from 'src/app/models/customer.model';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-delete-customer-form-dialog',
  templateUrl: './delete-customer-form-dialog.component.html',
  styleUrls: ['./delete-customer-form-dialog.component.scss']
})
export class DeleteCustomerFormDialogComponent implements OnInit {

errors: any = {};

  constructor(
    @Inject(MAT_DIALOG_DATA) private _customer: Customer,
    private _snackBar: MatSnackBar,
    private _dialogRef: MatDialogRef<DeleteCustomerFormDialogComponent>,
    private _customerService: CustomerService) { }

  ngOnInit(): void {

  }

  onSubmit(): void {
    this._customerService.delete(this._customer.id!).subscribe(
      success => {
        this._dialogRef.close({ data: success });
      },
      fail => {
        this.errors = fail.error.Errors;
        this.showSnackBarErrors();
      }
    );
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
