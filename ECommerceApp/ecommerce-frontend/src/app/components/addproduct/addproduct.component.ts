import { Component } from '@angular/core';
import { Addproduct } from '../../models/addproduct';
import { ProductsService } from '../../services/products.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-addproduct',
  imports: [CommonModule, FormsModule],
  templateUrl: './addproduct.component.html',
  styleUrl: './addproduct.component.css'
})
export class AddProductComponent {
  product: Addproduct = new Addproduct();
  categories: any[] = [];

  constructor(private productService: ProductsService) {}

  addProduct() {
    this.productService.addProduct(this.product).subscribe(
      (response) => {
        alert('Product added successfully!');
        console.log(response);
        this.product = new Addproduct(); 
      },
      (error) => {
        alert('Failed to add product.');
        console.error(error);
      }
    );
  }

  getCategories() {
    this.productService.getCategories().subscribe(
      (res: any[]) => {
        this.categories = res; 
      },
      (error) => {
        console.error('Error fetching categories:', error);
      }
    );
  }

}
