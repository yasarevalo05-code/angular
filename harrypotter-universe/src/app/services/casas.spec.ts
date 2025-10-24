import { TestBed } from '@angular/core/testing';

import { Casas } from './casas';

describe('Casas', () => {
  let service: Casas;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Casas);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
