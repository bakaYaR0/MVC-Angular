import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { Book } from './models/book';

@Component({
  selector: 'app',
  templateUrl: './app.component.html',
  providers: [DataService]
})
export class AppComponent implements OnInit {

  product: Book = new Book();   // изменяемый товар
  products: Book[];                // массив товаров
  tableMode: boolean = true;          // табличный режим

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.loadProducts();    // загрузка данных при старте компонента  
  }
  // получаем данные через сервис
  loadProducts() {
    this.dataService.getProducts()
      .subscribe(data => {
        this.products = data;
      })
  }
  // сохранение данных
  save() {
    if (this.product.id == null) {
      this.dataService.createProduct(this.product)
        .subscribe((data: Book) => this.products.push(data));
    } else {
      this.dataService.updateProduct(this.product)
        .subscribe(data => this.loadProducts());
    }
    this.cancel();
  }
  editProduct(p: Book) {
    this.product = p;
  }
  cancel() {
    this.product = new Book();
    this.tableMode = true;
  }
  delete(p: Book) {
    this.dataService.deleteProduct(p.id)
      .subscribe(data => this.loadProducts());
  }
  add() {
    this.cancel();
    this.tableMode = false;
  }
}
