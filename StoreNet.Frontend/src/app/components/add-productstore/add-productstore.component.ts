import { Component, OnInit } from '@angular/core';
import { Productstore } from 'src/app/models/productstore.model';
import { ProductstoreService } from 'src/app/services/productstore.service';
import { StoreService } from 'src/app/services/store.service';
import { ProductService } from 'src/app/services/product.service';
import { Store } from '../../models/store.model';
import { Product } from '../../models/product.model';

@Component({
  selector: 'app-add-productstore',
  templateUrl: './add-productstore.component.html',
  styleUrls: ['./add-productstore.component.css']
})
export class AddProductstoreComponent implements OnInit {

  productstore: Productstore = {
    id: 0,
    storeId: 0,
    productId: 0,
    createdDate: new Date(),
    updatedDate: new Date(),
  };
  submitted = false;
  stores: Store[] = [];
  products: Product[] = [];


  constructor(private productstoreService: ProductstoreService,
    private storeService: StoreService,
    private productService: ProductService) { }

  ngOnInit(): void {
    this.storeService.getAll()
      .subscribe({
        next: (res) => {
          this.stores = res;
        },
        error: (e) => alert(e.error)
      });
    this.productService.getAll()
      .subscribe({
        next: (res) => {
          this.products = res;
        },
        error: (e) => alert(e.error)
      });
  }

  saveProductstore(): void {
    const data = {
      storeId: this.productstore.storeId,
      productId: this.productstore.productId,
    };

    this.productstoreService.create(data)
      .subscribe({
        next: (res) => {
          this.submitted = true;
        },
        error: (e) => alert(e.error)
      });
  }

  newProductstore(): void {
    this.submitted = false;
    this.productstore = {
      storeId: 0,
      productId: 0,
    };
  }

}
