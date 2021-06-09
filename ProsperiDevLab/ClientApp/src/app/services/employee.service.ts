import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Employee } from '../models/employee.model';
import { CrudService } from './crud.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService extends CrudService<number, Employee> {

  constructor(protected _httpClient: HttpClient) {
    super(_httpClient, environment.API_URL + "/employees");
  }

}
