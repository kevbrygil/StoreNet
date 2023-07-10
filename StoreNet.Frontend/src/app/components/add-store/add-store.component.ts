import { Component, OnInit } from '@angular/core';
import { Store } from 'src/app/models/store.model';
import { StoreService } from 'src/app/services/store.service';

@Component({
  selector: 'app-add-store',
  templateUrl: './add-store.component.html',
  styleUrls: ['./add-store.component.css']
})
export class AddStoreComponent {

  store: Store = {
    id: 0,
    branch: '',
    address: '',
  };
  submitted = false;

  constructor(private storeService: StoreService) { }

  ngOnInit(): void {
  }

  saveStore(): void {
    const data = {
      branch: this.store.branch,
      address: this.store.address,
    };

    this.storeService.create(data)
      .subscribe({
        next: (res) => {
          this.submitted = true;
        },
        error: (e) => alert(e.error)
      });
  }

  newStore(): void {
    this.submitted = false;
    this.store = {
      id: 0,
      branch: '',
      address: '',
    };
  }

}
