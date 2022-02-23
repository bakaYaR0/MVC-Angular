import { Component, OnInit } from '@angular/core';
import { Book } from 'src/app/models/book';
import { DataService } from 'src/app/services/data.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-add-new',
    templateUrl: './addnew.component.html'
})
export class AddNewComponent implements OnInit {
    submitted = false;
    book: Book = {
        bookID: '',
        isbn: '',
        title: '',
        subtitle: '',
        author: '',
        publisher: '',
        pages: 0,
        value: 0,
        amountInStock: 0,
        description: '',
    };

    constructor(private dataService: DataService,
        private router: Router
    ) { }

    ngOnInit(): void {
    }
    saveBook(): void {
        const data = {
            id: this.book.bookID,
            isbn: this.book.isbn,
            title: this.book.title,
            subtitle: this.book.subtitle,
            author: this.book.author,
            publisher: this.book.publisher,
            pages: this.book.pages,
            value: this.book.value,
            amountInStock: this.book.amountInStock,
            description: this.book.description
        };
        this.dataService.createProduct(data)
            .subscribe({
                next: (res) => {
                    console.log(res);
                    this.submitted = true;
                },
                error: (e) => console.error(e)
            });
        this.router.navigateByUrl('catalog')
    }
    newBook(): void {
        this.submitted = false;
        this.book = {
            bookID: '',
            isbn: '',
            title: '',
            subtitle: '',
            author: '',
            publisher: '',
            pages: 0,
            value: 0,
            amountInStock: 0,
            description: '',
        };
    }
}