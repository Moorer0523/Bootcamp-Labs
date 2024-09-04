import { TestBed } from '@angular/core/testing';

import { AlumniAPIService } from './alumni-api.service';

describe('AlumniAPIService', () => {
  let service: AlumniAPIService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AlumniAPIService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
