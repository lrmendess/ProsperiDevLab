import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

import { ServiceOrder } from '../models/service-order.model';
import { CrudService } from './crud.service';

@Injectable({
  providedIn: 'root'
})
export class ServiceOrderService extends CrudService<number, ServiceOrder> {

  constructor(protected _httpClient: HttpClient) {
    super(_httpClient, "https://localhost:44390/api/serviceOrders");
  }

}
