import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { DataService } from 'src/app/services/data.service';
import { Book } from 'src/app/models/book';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  providers: [DataService],
})

export class CatalogComponent implements OnInit {

  product: Book = new Book();   
  products!: Book[];                
  tableMode: boolean = true;          

  constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadProducts();      
    }
  
    loadProducts() {
        this.dataService.getProducts()
            .subscribe((data:any) => {
            this.products = data;
            })
    }

    showDetails() {
        this.dataService.getProduct(this.product.id)
            .subscribe((data: any) => {
                this.product = data;
            })
    }
    addToCart() { }
}
