import { TestBed } from '@angular/core/testing';

import { PostdirectoryService } from './postdirectory.service';

describe('PostdirectoryService', () => {
  let service: PostdirectoryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PostdirectoryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
