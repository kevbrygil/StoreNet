import { Component, OnInit } from '@angular/core';
import { Sale } from 'src/app/models/sale.model';
import { SaleService } from 'src/app/services/sale.service';
import { CustomerService } from 'src/app/services/customer.service';
import { ProductService } from 'src/app/services/product.service';
import { Customer } from '../../models/customer.model';
import { Product } from '../../models/product.model';

@Component({
    selector: 'app-add-sale',
    templateUrl: './add-sale.component.html',
    styleUrls: ['./add-sale.component.css']
})
export class AddSaleComponent implements OnInit {

  sale: Sale = {
      id: 0,
      customerId: 0,
      productId: 0,
      quantity: 0,
      unitPrice: 0,
      total: 0,
      createdDate: new Date(),
      updatedDate: new Date(),
  };
  submitted = false;
  customers: Customer[] = [];
  products: Product[] = [];


  constructor(private saleService: SaleService,
    private customerService: CustomerService,
    private productService: ProductService) { }

    ngOnInit(): void {
      this.customerService.getAll()
        .subscribe({
          next: (res) => {
            this.customers = res;
          },
          error: (e) => alert(e.error)
        });
      this.productService.getAll()
        .subscribe({
          next: (res) => {
            this.products= res;
          },
          error: (e) => alert(e.error)
        });
    }

    saveSale(): void {
        const data = {
            customerId: this.sale.customerId,
            productId: this.sale.productId,
            quantity: this.sale.quantity
        };

        this.saleService.create(data)
            .subscribe({
                next: (res) => {
                    this.submitted = true;
                },
              error: (e) => alert(e.error)
            });
    }

    newSale(): void {
        this.submitted = false;
        this.sale = {
            customerId: 0,
            productId: 0,
            quantity: 0,
        };
    }

}
