import { Component, OnInit } from '@angular/core';

import { DataService } from 'src/app/services/data.service';
import { Book } from 'src/app/models/book';

@Component({
  selector: 'app-catalog',
  templateUrl: './catalog.component.html',
  providers: [DataService],
})

export class CatalogComponent implements OnInit {

    searchString: string = '';
    product: Book = {};
    products?: Book[];
    displayedProducts?: Book[];

  constructor(private dataService: DataService) { }

    ngOnInit() : void {
        this.loadProducts();      
    }
  
    loadProducts() : void {
        this.dataService.getProducts()
            .subscribe({
                next: (data) => {
                    this.products = data;
                    this.displayedProducts = data;
                    console.log(data)
                },
                error: (e) => console.error(e)
            });
    }

    findBook(): void {
        
        this.displayedProducts = this.products?.filter(book =>
            book.isbn?.includes(this.searchString) ||
            book.author?.includes(this.searchString) ||
            book.title?.includes(this.searchString));
    }
}
