import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductstoreListComponent } from './productstore-list.component';

describe('ProductstoreListComponent', () => {
  let component: ProductstoreListComponent;
  let fixture: ComponentFixture<ProductstoreListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProductstoreListComponent]
    });
    fixture = TestBed.createComponent(ProductstoreListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
