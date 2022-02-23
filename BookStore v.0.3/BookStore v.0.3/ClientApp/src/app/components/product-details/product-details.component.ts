import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from 'src/app/models/book';
import { DataService } from 'src/app/services/data.service';

@Component({
    selector: 'app-product-details',
    templateUrl: './product-details.component.html'
})
export class ProductDetailsComponent implements OnInit {

    id!: any;
    book!: Book;

    constructor(
        private dataService: DataService,
        private route: ActivatedRoute,
        private router: Router
    ) { }

    ngOnInit(): void {

        this.id = this.route.snapshot.params['bookID'];
        this.dataService.getProduct(this.id)
            .subscribe({
                next: (data) => {
                this.book = data;
                console.log(data);
            },
                error: (e) => console.error(e)
            });
    }

    deleteBook(): void {
        this.dataService.deleteProduct(this.id)
            .subscribe({
                next: (res) => {
                    console.log(res);
                    this.router.navigate(['/catalog']);
                },
                error: (e) => console.error(e)
            });           
    }
}
