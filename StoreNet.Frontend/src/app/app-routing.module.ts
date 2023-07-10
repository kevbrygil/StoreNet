import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SaleListComponent } from './components/sale-list/sale-list.component';
import { SaleDetailsComponent } from './components/sale-details/sale-details.component';
import { AddSaleComponent } from './components/add-sale/add-sale.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { AddProductComponent } from './components/add-product/add-product.component';
import { CustomerListComponent } from './components/customer-list/customer-list.component';
import { CustomerDetailsComponent } from './components/customer-details/customer-details.component';
import { AddCustomerComponent } from './components/add-customer/add-customer.component';
import { ProductstoreListComponent } from './components/productstore-list/productstore-list.component';
import { ProductstoreDetailsComponent } from './components/productstore-details/productstore-details.component';
import { AddProductstoreComponent } from './components/add-productstore/add-productstore.component';
import { AddStoreComponent } from './components/add-store/add-store.component';
import { StoreListComponent } from './components/store-list/store-list.component';
import { StoreDetailsComponent } from './components/store-details/store-details.component';

const routes: Routes = [
  { path: '', redirectTo: 'products', pathMatch: 'full' },
  { path: 'sales', component: SaleListComponent },
  { path: 'sales/:id', component: SaleDetailsComponent },
  { path: 'addsale', component: AddSaleComponent },
  { path: 'products', component: ProductListComponent },
  { path: 'products/:id', component: ProductDetailsComponent },
  { path: 'addproduct', component: AddProductComponent },
  { path: 'customers', component: CustomerListComponent },
  { path: 'customers/:id', component: CustomerDetailsComponent },
  { path: 'addcustomer', component: AddCustomerComponent },
  { path: 'productsstores', component: ProductstoreListComponent },
  { path: 'productsstores/:id', component: ProductstoreDetailsComponent },
  { path: 'addproductstore', component: AddProductstoreComponent },
  { path: 'addstore', component: AddStoreComponent },
  { path: 'stores', component: StoreListComponent },
  { path: 'stores/:id', component: StoreDetailsComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
