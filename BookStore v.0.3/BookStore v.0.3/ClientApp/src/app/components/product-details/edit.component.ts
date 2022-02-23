import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Book } from 'src/app/models/book';
import { DataService } from 'src/app/services/data.service';

@Component({
    selector: 'app-edit',
    templateUrl: './edit.component.html'
})

export class EditComponent implements OnInit {

    id!: any;
    book!: Book;
    form!: FormGroup;

    constructor(
        private dataService: DataService,
        private route: ActivatedRoute,
        private router: Router
    ) { }

    ngOnInit(): void {
        this.id = this.route.snapshot.params['bookID'];
        this.dataService.getProduct(this.id)
            .subscribe((data: Book) => {
            this.book = data;
        });
    }

    saveBook(): void {
        console.log(this.book);
        this.dataService.updateProduct(this.id, this.book)
            .subscribe((res: any) => {
                console.log();
            this.router.navigateByUrl('catalog/' + this.book.bookID + '/details');
            })
    }
}