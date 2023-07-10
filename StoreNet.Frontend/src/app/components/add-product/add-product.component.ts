import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {

  product: Product = {
    id: 0,
    barcode: '',
    description: '',
    image: null,
    price: 0.00,
    stock: 0,
  };
  submitted = false;

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
  }

  saveProduct(): void {
    const data = {
      barcode: this.product.barcode,
      description: this.product.description,
      image: null,
      price: this.product.price,
      stock: this.product.stock,
    };

    this.productService.create(data)
      .subscribe({
        next: (res) => {
          this.submitted = true;
        },
        error: (e) => alert(e.error)
      });
  }

  newProduct(): void {
    this.submitted = false;
    this.product = {
      id: 0,
      barcode: '',
      description: '',
      image: null,
      price: 0.00,
      stock: 0,
    };
  }

}
