import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Products } from '../models/products';
import { Cart } from '../models/cart';
import { Addproduct } from '../models/addproduct';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private apiUrl = 'https://localhost:7205/api/Product';

  constructor(private http: HttpClient) {}
  getAllProducts():Observable<Products[]>{
    return this.http.get<Products[]>(this.apiUrl);
  }
  addToCart(cart:Cart){
    return this.http.post<Cart>('https://localhost:7205/api/Cart', cart);
  }
  addProduct(product:Addproduct):Observable<Addproduct>{
    return this.http.post<Addproduct>('https://localhost:7205/api/Product', product);
  }
  deleteProduct(productId:number): Observable<Products>{
    return this.http.delete<Products>(`https://localhost:7205/api/Product/${productId}`);
  }
  getCategories(): Observable<any[]> {
    return this.http.get<any[]>('https://localhost:7205/api/Category');
  }
}
