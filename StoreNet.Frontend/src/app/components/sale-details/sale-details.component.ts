import { Component, Input, OnInit } from '@angular/core';
import { SaleService } from 'src/app/services/sale.service';
import { CustomerService } from 'src/app/services/customer.service';
import { ProductService } from 'src/app/services/product.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Sale } from 'src/app/models/sale.model';
import { Customer } from '../../models/customer.model';
import { Product } from '../../models/product.model';

@Component({
  selector: 'app-sale-details',
  templateUrl: './sale-details.component.html',
  styleUrls: ['./sale-details.component.css']
})
export class SaleDetailsComponent implements OnInit {
  @Input() viewMode = false;

  @Input() currentSale: Sale = {
    id: 0,
    customerId: 0,
    productId: 0,
    quantity: 0,
    unitPrice: 0,
    total: 0,
    createdDate: new Date(),
    updatedDate: new Date(),
  };

  message = '';
  customers: Customer[] = [];
  products: Product[] = [];

  constructor(
    private saleService: SaleService,
    private route: ActivatedRoute,
    private router: Router,
    private customerService: CustomerService,
    private productService: ProductService) { }

  ngOnInit(): void {
    if (!this.viewMode) {
      this.message = '';
      this.getSale(this.route.snapshot.params["id"]);
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
            this.products = res;
          },
          error: (e) => alert(e.error)
        });
    }
  }

  getSale(id: string): void {
    this.saleService.getById(id)
      .subscribe({
        next: (data) => {
          this.currentSale = data;
          console.log(data);
        },
        error: (e) => console.error(e)
      });
  }

  updateSale(): void {
    this.message = '';

    this.saleService.update(this.currentSale.id, this.currentSale)
      .subscribe({
        next: (res) => {
          this.message = res.message ? res.message : 'Se actualizo exitosamente!';
        },
        error: (e) => console.error(e)
      });
  }

  deleteSale(): void {
    this.saleService.delete(this.currentSale.id)
      .subscribe({
        next: (res) => {
          this.router.navigate(['/sales']);
        },
        error: (e) => console.error(e)
      });
  }
}
