import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from 'src/app/components/home/home.component';
import { CatalogComponent } from 'src/app/components/catalog/catalog.component';
import { AboutComponent } from 'src/app/components/about/about.component';
import { ContactsComponent } from 'src/app/components/contacts/contacts.component';
import { AddNewComponent } from './components/catalog/addnew.component';

const routes: Routes = [
    { path: 'catalog', component: CatalogComponent },
    { path: 'home', component: HomeComponent },
    { path: 'about', component: AboutComponent },
    { path: 'contact', component: ContactsComponent },
    { path: 'addnew', component: AddNewComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
