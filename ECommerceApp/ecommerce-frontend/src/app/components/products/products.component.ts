import { Component } from '@angular/core';
import { Products } from '../../models/products';
import { ProductsService } from '../../services/products.service';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Cart } from '../../models/cart';

@Component({
  selector: 'app-products',
  imports: [RouterModule, CommonModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent {
  cart?:Cart=new Cart();
  cartHolder?:Cart[];
  products:Products[]=[];
  constructor(private productService:ProductsService){}
  ngOnInit(){
    this.getAllProducts();
    
  }

  getAllProducts(){
    this.productService.getAllProducts().subscribe(res=>{
      this.products=(res);
    })
  }
  addToCart(productId?: number) {
    if (!productId) {
      alert("Invalid product ID!");
      return;
    }
  
    const cartItem: Cart = {
      userId: localStorage.getItem('email') ?? "",  // Ensure userId is not null
      quantity: 1,
      productId: productId
    };
  
    this.productService.addToCart(cartItem).subscribe({
      next: (res) => {
        alert("Added to cart successfully!!");
        console.log(res);
        this.cartHolder?.push(res);
      },
      error: (err) => {
        console.error("Error adding to cart:", err);
        alert("Failed to add to cart!");
      }
    });
  }
  
}
