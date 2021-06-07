import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ServiceOrder } from 'src/app/models/service-order.model';
import { ServiceOrderService } from 'src/app/services/service-order.service';

@Component({
  selector: 'app-delete-service-order-form-dialog',
  templateUrl: './delete-service-order-form-dialog.component.html',
  styleUrls: ['./delete-service-order-form-dialog.component.scss']
})
export class DeleteServiceOrderDialogComponent implements OnInit {

  constructor(
    private _serviceOrderService: ServiceOrderService,
    @Inject(MAT_DIALOG_DATA) public serviceOrder: ServiceOrder
    ) { }

  ngOnInit(): void {
  }

  deleteServiceOrder(): void {
    console.log(this.serviceOrder);

    this._serviceOrderService.delete(this.serviceOrder.id!);
  }

}
