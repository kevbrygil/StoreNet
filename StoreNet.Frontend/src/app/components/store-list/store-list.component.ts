import { Component, OnInit, Input } from '@angular/core';
import { Store } from 'src/app/models/store.model';
import { StoreService } from 'src/app/services/store.service';

@Component({
  selector: 'app-store-list',
  templateUrl: './store-list.component.html',
  styleUrls: ['./store-list.component.css']
})
export class StoreListComponent implements OnInit {
  @Input() viewMode = false;

  @Input() currentStore: Store = {
    id: 0,
    branch: '',
    address: ''
  };

  stores?: Store[];
  currentIndex = -1;
  idSearch = '';

  constructor(private storeService: StoreService) { }

  ngOnInit(): void {
    this.retrieveStores();
  }

  retrieveStores(): void {
    this.storeService.getAll()
      .subscribe({
        next: (data) => {
          this.stores = data;
        },
        error: (e) => alert(e.error)
      });
  }

  refreshList(): void {
    this.retrieveStores();
    this.currentStore = {};
    this.currentIndex = -1;
  }

  setActiveStore(store: Store, index: number): void {
    this.currentStore = store;
    this.currentIndex = index;
  }

  searchById(): void {
    if (!this.idSearch) return;

    this.currentStore = {};
    this.currentIndex = -1;

    this.storeService.getById(this.idSearch)
      .subscribe({
        next: (data) => {
          this.stores = [data];
        },
        error: (e) => {
          this.stores = [];
        }
      });
  }

  clearSearch(): void {
    this.idSearch = '';
    this.refreshList();
  }
}
