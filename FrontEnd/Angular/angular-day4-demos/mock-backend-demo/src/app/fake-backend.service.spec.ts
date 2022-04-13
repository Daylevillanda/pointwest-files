import { TestBed } from '@angular/core/testing';

import { FakeBackendService } from './fake-backend.service';

describe('FakeBackendService', () => {
  let service: FakeBackendService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FakeBackendService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
