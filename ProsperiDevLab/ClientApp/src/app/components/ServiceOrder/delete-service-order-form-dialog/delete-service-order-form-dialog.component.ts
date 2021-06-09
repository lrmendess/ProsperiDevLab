import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ServiceOrder } from 'src/app/models/service-order.model';
import { ServiceOrderService } from 'src/app/services/service-order.service';

@Component({
  selector: 'app-delete-service-order-form-dialog',
  templateUrl: './delete-service-order-form-dialog.component.html',
  styleUrls: ['./delete-service-order-form-dialog.component.scss']
})
export class DeleteServiceOrderDialogComponent implements OnInit {

  errors: any = {};

  constructor(
    @Inject(MAT_DIALOG_DATA) private _serviceOrder: ServiceOrder,
    private _snackBar: MatSnackBar,
    private _dialogRef: MatDialogRef<DeleteServiceOrderDialogComponent>,
    private _serviceOrderService: ServiceOrderService) { }

  ngOnInit(): void {

  }

  onSubmit(): void {
    this._serviceOrderService.delete(this._serviceOrder.id!).subscribe(
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
