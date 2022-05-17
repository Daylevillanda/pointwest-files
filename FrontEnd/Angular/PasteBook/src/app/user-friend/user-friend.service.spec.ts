import { TestBed } from '@angular/core/testing';

import { UserFriendService } from './user-friend.service';

describe('UserFriendService', () => {
  let service: UserFriendService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserFriendService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
