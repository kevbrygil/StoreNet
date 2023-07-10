import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddProductstoreComponent } from './add-productstore.component';

describe('AddProductstoreComponent', () => {
  let component: AddProductstoreComponent;
  let fixture: ComponentFixture<AddProductstoreComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddProductstoreComponent]
    });
    fixture = TestBed.createComponent(AddProductstoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
