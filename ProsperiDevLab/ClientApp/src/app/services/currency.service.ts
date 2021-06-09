import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Currency } from '../models/currency.model';
import { CrudService } from './crud.service';

@Injectable({
  providedIn: 'root'
})
export class CurrencyService extends CrudService<number, Currency> {

  constructor(protected _httpClient: HttpClient) {
    super(_httpClient, environment.API_URL + "/currencies");
  }
  
}
