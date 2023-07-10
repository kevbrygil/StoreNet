import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductstoreDetailsComponent } from './productstore-details.component';

describe('ProductstoreDetailsComponent', () => {
  let component: ProductstoreDetailsComponent;
  let fixture: ComponentFixture<ProductstoreDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProductstoreDetailsComponent]
    });
    fixture = TestBed.createComponent(ProductstoreDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
