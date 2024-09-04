import { TestBed } from '@angular/core/testing';

import { DonutAPIService } from './donut-api.service';

describe('DonutAPIService', () => {
  let service: DonutAPIService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DonutAPIService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
