import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Customer } from '../models/customer.model';
import { CrudService } from './crud.service';

@Injectable({
  providedIn: 'root'
})
export class CustomerService extends CrudService<number, Customer> {

  constructor(protected _httpClient: HttpClient) {
    super(_httpClient, environment.API_URL + "/customers");
  }

}
