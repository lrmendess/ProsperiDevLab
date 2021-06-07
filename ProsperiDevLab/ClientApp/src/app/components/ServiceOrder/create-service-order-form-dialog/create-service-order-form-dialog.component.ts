import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ServiceOrder } from 'src/app/models/service-order.model';
import { ServiceOrderService } from 'src/app/services/service-order.service';

@Component({
  selector: 'app-create-service-order-form-dialog',
  templateUrl: './create-service-order-form-dialog.component.html',
  styleUrls: ['./create-service-order-form-dialog.component.scss']
})
export class CreateServiceOrderFormComponent implements OnInit {

  serviceOrder: ServiceOrder = {
    number: '',
    title: '',
  };

  constructor(private _serviceOrderService: ServiceOrderService) { }

  ngOnInit(): void {
  }

  createServiceOrder(): void {
    console.log(this.serviceOrder)

    this._serviceOrderService.create(this.serviceOrder)
      .subscribe(
        response => {
          // console.log(response);
        },
        error => {
          // console.log(error);
        }
      );
  }

}
