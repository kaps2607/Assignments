import { bootstrapApplication } from '@angular/platform-browser';
import { provideRouter, Routes } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { importProvidersFrom } from '@angular/core';
import { AppComponent } from './app/app.component';
import { LoginComponent } from './app/components/login/login.component';
import { ProductsComponent } from './app/components/products/products.component';
import { appConfig } from './app/app.config';


// const routes: Routes = [
//   { path: 'login', component: LoginComponent },
//   { path: '**', redirectTo: 'login' }, // Redirect any unknown routes to login
//   { path: 'products', component: ProductsComponent}
// ];

bootstrapApplication(AppComponent, appConfig).catch((err) => console.error(err));
