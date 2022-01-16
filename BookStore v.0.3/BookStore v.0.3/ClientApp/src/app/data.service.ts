import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Book } from './models/book';

@Injectable()
export class DataService {

  private url = "/api/books";

  constructor(private http: HttpClient) {
  }

  getProducts() {
    return this.http.get<Book[]>(this.url);
  }

  getProduct(id: number) {
    return this.http.get(this.url + '/' + id);
  }

  createProduct(product: Book) {
    return this.http.post(this.url, product);
  }
  updateProduct(product: Book) {

    return this.http.put(this.url, product);
  }
  deleteProduct(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}
