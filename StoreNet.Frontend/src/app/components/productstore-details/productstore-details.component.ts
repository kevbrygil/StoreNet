import { Component, Input, OnInit } from '@angular/core';
import { ProductstoreService } from 'src/app/services/productstore.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Productstore } from 'src/app/models/productstore.model';
import { StoreService } from 'src/app/services/store.service';
import { ProductService } from 'src/app/services/product.service';
import { Store } from '../../models/store.model';
import { Product } from '../../models/product.model';

@Component({
  selector: 'app-productstore-details',
  templateUrl: './productstore-details.component.html',
  styleUrls: ['./productstore-details.component.css']
})
export class ProductstoreDetailsComponent implements OnInit{
  @Input() viewMode = false;

  @Input() currentProductstore: Productstore = {
    id: 0,
    createdDate: new Date(),
    updatedDate: new Date(),
    productId: 0,
    storeId: 0,
  };

  stores: Store[] = [];
  products: Product[] = [];

  message = '';

  constructor(
    private productstoreService: ProductstoreService,
    private route: ActivatedRoute,
    private router: Router,
    private storeService: StoreService,
    private productService: ProductService) { }

  ngOnInit(): void {
    if (!this.viewMode) {
      this.message = '';
      this.getProductstore(this.route.snapshot.params["id"]);
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
  }

  getProductstore(id: string): void {
    this.productstoreService.getById(id)
      .subscribe({
        next: (data) => {
          this.currentProductstore = data;
          console.log(data);
        },
        error: (e) => console.error(e)
      });
  }

  updateProductstore(): void {
    this.message = '';

    this.productstoreService.update(this.currentProductstore.id, this.currentProductstore)
      .subscribe({
        next: (res) => {
          this.message = res.message ? res.message : 'Se actualizo exitosamente!';
        },
        error: (e) => console.error(e)
      });
  }

  deleteProductstore(): void {
    this.productstoreService.delete(this.currentProductstore.id)
      .subscribe({
        next: (res) => {
          this.router.navigate(['/productsstores']);
        },
        error: (e) => console.error(e)
      });
  }
}
