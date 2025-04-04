import { Component } from '@angular/core';
import { Products } from '../../models/products';
import { ProductsService } from '../../services/products.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-deleteproduct',
  imports: [CommonModule, FormsModule],
  templateUrl: './deleteproduct.component.html',
  styleUrl: './deleteproduct.component.css'
})
export class DeleteproductComponent {
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
    pid?:number|null=0;
    deleteProduct(productId: number | null | undefined) {
      if (!productId) {
        alert("Invalid product ID!");
        return;
      }
      if (confirm('Are you sure you want to delete this product?')) {
        this.productService.deleteProduct(productId).subscribe(
          (res) => {
            alert('Product deleted successfully!');
            this.products = this.products.filter(product => product.productId !== productId);
          },
          (error) => {
            alert('Failed to delete product.');
            console.error('Error deleting product:', error);
          }
        );
      }
    }
}
