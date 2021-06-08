import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ServiceOrder } from 'src/app/models/service-order.model';
import { ServiceOrderService } from 'src/app/services/service-order.service';

@Component({
  selector: 'app-delete-service-order-form-dialog',
  templateUrl: './delete-service-order-form-dialog.component.html',
  styleUrls: ['./delete-service-order-form-dialog.component.scss']
})
export class DeleteServiceOrderDialogComponent implements OnInit {

  constructor(
    @Inject(MAT_DIALOG_DATA) public serviceOrder: ServiceOrder,
    private dialogRef: MatDialogRef<DeleteServiceOrderDialogComponent>,
    private _serviceOrderService: ServiceOrderService) { }

  ngOnInit(): void {

  }

  deleteServiceOrder(): void {
    this._serviceOrderService.delete(this.serviceOrder.id!).subscribe(
      response => {
        this.dialogRef.close();
      },
      error => {
        console.log(error);
      }
    );
  }

}
