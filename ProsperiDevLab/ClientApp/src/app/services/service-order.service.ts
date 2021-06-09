import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

import { ServiceOrder } from '../models/service-order.model';
import { CrudService } from './crud.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ServiceOrderService extends CrudService<number, ServiceOrder> {

  constructor(protected _httpClient: HttpClient) {
    super(_httpClient, environment.API_URL + "/serviceOrders");
  }

}
