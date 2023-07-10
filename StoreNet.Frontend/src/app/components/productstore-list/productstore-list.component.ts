import { Component, OnInit, Input } from '@angular/core';
import { Productstore } from 'src/app/models/productstore.model';
import { ProductstoreService } from 'src/app/services/productstore.service';

@Component({
  selector: 'app-productstore-list',
  templateUrl: './productstore-list.component.html',
  styleUrls: ['./productstore-list.component.css']
})
export class ProductstoreListComponent implements OnInit {
  @Input() viewMode = false;

  @Input() currentProductstore: Productstore = {
    id: 0,
    createdDate: new Date(),
    updatedDate: new Date(),
    productId: 0,
    storeId: 0,
  };

  productstores?: Productstore[];
  currentIndex = -1;
  idSearch = '';

  constructor(private productstoreService: ProductstoreService) { }

  ngOnInit(): void {
    this.retrieveProductstores();
  }

  retrieveProductstores(): void {
    this.productstoreService.getAll()
      .subscribe({
        next: (data) => {
          this.productstores = data;
        },
        error: (e) => alert(e.error)
      });
  }

  refreshList(): void {
    this.retrieveProductstores();
    this.currentProductstore = {};
    this.currentIndex = -1;
  }

  setActiveProductstore(productstore: Productstore, index: number): void {
    this.currentProductstore = productstore;
    this.currentIndex = index;
  }

  searchById(): void {
    if (!this.idSearch) return;

    this.currentProductstore = {};
    this.currentIndex = -1;

    this.productstoreService.getById(this.idSearch)
      .subscribe({
        next: (data) => {
          this.productstores = [data];
        },
        error: (e) => {
          this.productstores = [];
        }
      });
  }

  clearSearch(): void {
    this.idSearch = '';
    this.refreshList();
  }
}
