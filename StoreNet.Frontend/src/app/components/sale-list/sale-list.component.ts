import { Component, OnInit, Input } from '@angular/core';
import { Sale } from 'src/app/models/sale.model';
import { SaleService } from 'src/app/services/sale.service';

@Component({
  selector: 'app-sale-list',
  templateUrl: './sale-list.component.html',
  styleUrls: ['./sale-list.component.css']
})
export class SaleListComponent implements OnInit{
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

  sales?: Sale[];
  currentIndex = -1;
  idSearch = '';

  constructor(private saleService: SaleService) { }

  ngOnInit(): void {
    this.retrieveSales();
  }

  retrieveSales(): void {
    this.saleService.getAll()
      .subscribe({
        next: (data) => {
          this.sales = data;
        },
        error: (e) => alert(e.error)
      });
  }

  refreshList(): void {
    this.retrieveSales();
    this.currentSale = {};
    this.currentIndex = -1;
  }

  setActiveSale(sale: Sale, index: number): void {
    this.currentSale = sale;
    this.currentIndex = index;
  }

  searchById(): void {
    if (!this.idSearch) return;

    this.currentSale = {};
    this.currentIndex = -1;

    this.saleService.getById(this.idSearch)
      .subscribe({
        next: (data) => {
          this.sales = [data];
        },
        error: (e) => {
          this.sales = [];
        }
      });
  }

  clearSearch(): void {
    this.idSearch = '';
    this.refreshList();
  }
}
