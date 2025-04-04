import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { ProductsComponent } from './components/products/products.component';
import { RegisterComponent } from './components/register/register.component';
import { AddProductComponent } from './components/addproduct/addproduct.component';
import { DeleteproductComponent } from './components/deleteproduct/deleteproduct.component';

export const routes: Routes = [
  // { path: '', redirectTo: 'login', pathMatch: 'full' }, 
  { path: '', component: LoginComponent }, 
  { path: 'register', component: RegisterComponent }, 
  // { path: '**', redirectTo: 'login' },
  { path: 'products', component: ProductsComponent},
  { path: 'addProduct', component: AddProductComponent},
  { path:'deleteProduct', component: DeleteproductComponent}
];
