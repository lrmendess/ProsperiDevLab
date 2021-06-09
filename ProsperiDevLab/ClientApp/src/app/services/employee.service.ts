import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../models/employee.model';
import { CrudService } from './crud.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService extends CrudService<number, Employee> {

    constructor(protected _httpClient: HttpClient) {
    super(_httpClient, "https://localhost:44390/api/employees");
  }

}
