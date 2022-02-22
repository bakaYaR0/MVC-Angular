import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from 'src/app/components/home/home.component';
import { CatalogComponent } from 'src/app/components/catalog/catalog.component';
import { AboutComponent } from 'src/app/components/about/about.component';
import { ContactsComponent } from 'src/app/components/contacts/contacts.component';
import { AddNewComponent } from './components/catalog/addnew.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { EditComponent } from './components/product-details/edit.component';

const routes: Routes = [
    { path: 'catalog', component: CatalogComponent },
    { path: 'home', component: HomeComponent },
    { path: 'about', component: AboutComponent },
    { path: 'contact', component: ContactsComponent },
    { path: 'addnew', component: AddNewComponent },
    { path: 'catalog/:bookID/details', component: ProductDetailsComponent },
    { path: 'catalog/:bookID/edit', component: EditComponent},
    { path: '**', redirectTo: '/home' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
