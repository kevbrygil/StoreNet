import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Sale } from '../models/sale.model';
import { environment } from 'src/environments/environment';

const baseUrl = environment.urlBackend + '/api/Sales';

@Injectable({
    providedIn: 'root'
})
export class SaleService {

    constructor(private http: HttpClient) { }

    getAll(): Observable<Sale[]> {
      return this.http.get<Sale[]>(baseUrl);
    }

    getById(id: any): Observable<Sale> {
      return this.http.get<Sale>(`${baseUrl}/${id}`);
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
