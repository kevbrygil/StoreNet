import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Productstore } from '../models/productstore.model';
import { environment } from 'src/environments/environment';

const baseUrl = environment.urlBackend + '/api/ProductsStores';

@Injectable({
  providedIn: 'root'
})
export class ProductstoreService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<Productstore[]> {
    return this.http.get<Productstore[]>(baseUrl);
  }

  getById(id: any): Observable<Productstore> {
    return this.http.get<Productstore>(`${baseUrl}/${id}`);
  }

  create(data: any): Observable<any> {
    return this.http.post(baseUrl, data);
  }

  update(id: any, data: any): Observable<any> {
    return this.http.put(`${baseUrl}/${id}`, data);
  }

  delete(id: any): Observable<any> {
    return this.http.delete(`${baseUrl}/${id}`);
  }

}
