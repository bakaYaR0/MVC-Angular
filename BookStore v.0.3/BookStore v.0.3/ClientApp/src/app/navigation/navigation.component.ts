import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}