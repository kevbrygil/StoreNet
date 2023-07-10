import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AddSaleComponent } from './components/add-sale/add-sale.component';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SaleListComponent } from './components/sale-list/sale-list.component';
import { SaleDetailsComponent } from './components/sale-details/sale-details.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { AddProductComponent } from './components/add-product/add-product.component';
import { AddCustomerComponent } from './components/add-customer/add-customer.component';
import { CustomerDetailsComponent } from './components/customer-details/customer-details.component';
import { CustomerListComponent } from './components/customer-list/customer-list.component';
import { ProductstoreListComponent } from './components/productstore-list/productstore-list.component';
import { ProductstoreDetailsComponent } from './components/productstore-details/productstore-details.component';
import { AddProductstoreComponent } from './components/add-productstore/add-productstore.component';
import { AddStoreComponent } from './components/add-store/add-store.component';
import { StoreDetailsComponent } from './components/store-details/store-details.component';
import { StoreListComponent } from './components/store-list/store-list.component';

@NgModule({
  declarations: [
    AppComponent,
    AddSaleComponent,
    SaleListComponent,
    SaleDetailsComponent,
    ProductListComponent,
    ProductDetailsComponent,
    AddProductComponent,
    AddCustomerComponent,
    CustomerDetailsComponent,
    CustomerListComponent,
    ProductstoreListComponent,
    ProductstoreDetailsComponent,
    AddProductstoreComponent,
    AddStoreComponent,
    StoreDetailsComponent,
    StoreListComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
