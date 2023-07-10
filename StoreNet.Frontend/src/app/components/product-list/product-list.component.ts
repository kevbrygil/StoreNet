import { Component, OnInit, Input } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit{
  @Input() viewMode = false;

  @Input() currentProduct: Product = {
    id: 0,
    barcode: '',
    description: '',
    image: null,
    price: 0.00,
    stock: 0,
  };

  products?: Product[];
  currentIndex = -1;
  idSearch = '';

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.retrieveProducts();
  }

  retrieveProducts(): void {
    this.productService.getAll()
      .subscribe({
        next: (data) => {
          this.products = data;
        },
        error: (e) => alert(e.error)
      });
  }

  refreshList(): void {
    this.retrieveProducts();
    this.currentProduct = {};
    this.currentIndex = -1;
  }

  setActiveProduct(product: Product, index: number): void {
    this.currentProduct = product;
    this.currentIndex = index;
  }

  searchById(): void {
    if (!this.idSearch) return;

    this.currentProduct = {};
    this.currentIndex = -1;

    this.productService.getById(this.idSearch)
      .subscribe({
        next: (data) => {
          this.products = [data];
        },
        error: (e) => {
          this.products = [];
        }
      });
  }

  clearSearch(): void {
    this.idSearch = '';
    this.refreshList();
  }
}
