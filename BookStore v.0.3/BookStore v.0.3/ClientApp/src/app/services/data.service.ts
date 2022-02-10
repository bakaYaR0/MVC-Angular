import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Book } from '../models/book';
import { Observable } from 'rxjs';

@Injectable()
export class DataService {

  readonly CatalogUrl = "/api/catalog";

  constructor(private http: HttpClient) {
  }

  getProducts(): Observable<Book[]> {
      return this.http.get<Book[]>(this.CatalogUrl);
  }

  getProduct(id: any): Observable<Book> {
      return this.http.get(this.CatalogUrl + '/' + id);
  }

  createProduct(data: any) : Observable<any> {
      return this.http.post(this.CatalogUrl, data);
  }

  updateProduct(id: any, data: any) : Observable<any> {
      return this.http.put(this.CatalogUrl + '/' + id, data);
  }

  deleteProduct(id: any) : Observable<any> {
      return this.http.delete(this.CatalogUrl + '/' + id);
  }
}
