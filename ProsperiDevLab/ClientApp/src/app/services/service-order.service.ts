import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

import { Observable} from "rxjs";

import { ServiceOrder } from '../models/service-order.model';

@Injectable({
  providedIn: 'root'
})
export class ServiceOrderService {

  private apiPath: string = "api/serviceOrders"
  
  constructor(private http: HttpClient) { }

  get(id: Number) {
    return this.http.get(`${this.apiPath}/${id}`);
  }

  getAll(): Observable<ServiceOrder[]> {
    return this.http.get<ServiceOrder[]>(this.apiPath);
  }

  create(serviceOrder: any): Observable<ServiceOrder> {
    return this.http.post<ServiceOrder>(this.apiPath, { serviceOrder });
  }

  update(serviceOrder: any): Observable<ServiceOrder> {
    return this.http.put<ServiceOrder>(`${this.apiPath}/${serviceOrder.id}`, serviceOrder);
  }

  delete(id: Number) {
    return this.http.delete(`${this.apiPath}/${id}`);
  }

}
