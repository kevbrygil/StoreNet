import { Component, OnInit, Input } from '@angular/core';
import { Customer } from 'src/app/models/customer.model';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit{
  @Input() viewMode = false;

  @Input() currentCustomer: Customer = {
    id: 0,
    name: '',
    lastname: '',
    address: '',
  };

  customers?: Customer[];
  currentIndex = -1;
  idSearch = '';

  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
    this.retrieveCustomers();
  }

  retrieveCustomers(): void {
    this.customerService.getAll()
      .subscribe({
        next: (data) => {
          this.customers = data;
        },
        error: (e) => alert(e.error)
      });
  }

  refreshList(): void {
    this.retrieveCustomers();
    this.currentCustomer = {};
    this.currentIndex = -1;
  }

  setActiveCustomer(customer: Customer, index: number): void {
    this.currentCustomer = customer;
    this.currentIndex = index;
  }

  searchById(): void {
    if (!this.idSearch) return;

    this.currentCustomer = {};
    this.currentIndex = -1;

    this.customerService.getById(this.idSearch)
      .subscribe({
        next: (data) => {
          this.customers = [data];
        },
        error: (e) => {
          this.customers = [];
        }
      });
  }

  clearSearch(): void {
    this.idSearch = '';
    this.refreshList();
  }
}
