import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styles: []
})
export class AppComponent {
    title = 'Best Book Shop Ever';
    constructor(private router: Router) { }
    ngOnInit() { this.redirect() }
    redirect() {
        this.router.navigate(['home']);
    }
}
