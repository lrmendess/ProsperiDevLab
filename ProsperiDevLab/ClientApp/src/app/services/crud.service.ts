import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export abstract class CrudService<TKey, TEntity> {

  constructor(
    protected _httpClient: HttpClient,
    @Inject(String) protected _baseUrl: string) { }
  
  get(id: TKey) {
    return this._httpClient.get(`${this._baseUrl}/${id}`);
  }

  getAll(): Observable<TEntity[]> {
    return this._httpClient.get<TEntity[]>(this._baseUrl);
  }

  create(entity: TEntity): Observable<TEntity> {
    return this._httpClient.post<TEntity>(this._baseUrl, entity);
  }

  update(id: TKey, entity: TEntity): Observable<TEntity> {
    return this._httpClient.put<TEntity>(`${this._baseUrl}/${id}`, entity);
  }

  delete(id: TKey) {
    return this._httpClient.delete(`${this._baseUrl}/${id}`);
  }
  
}
