import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/models/customer.model';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})
export class AddCustomerComponent implements OnInit{
  customer: Customer = {
    id: 0,
    name: '',
    lastname: '',
    address: '',
  };
  submitted = false;

  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
  }

  saveCustomer(): void {
    const data = {
      name: this.customer.name,
      lastname: this.customer.lastname,
      address: this.customer.address,
    };

    this.customerService.create(data)
      .subscribe({
        next: (res) => {
          this.submitted = true;
        },
        error: (e) => alert(e.error)
      });
  }

  newCustomer(): void {
    this.submitted = false;
    this.customer = {
      id: 0,
      name: '',
      lastname: '',
      address: '',
    };
  }
}
