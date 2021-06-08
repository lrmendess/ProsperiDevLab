import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Customer } from '../models/customer.model';
import { CrudService } from './crud.service';

@Injectable({
  providedIn: 'root'
})
export class CustomerService extends CrudService<number, Customer> {

  constructor(protected _httpClient: HttpClient) {
    super(_httpClient, "https://localhost:44390/api/customers");
  }

}
