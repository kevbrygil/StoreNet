import { TestBed } from '@angular/core/testing';

import { ProductstoreService } from './productstore.service';

describe('ProductstoreService', () => {
  let service: ProductstoreService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductstoreService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
