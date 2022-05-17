import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserFriendComponent } from './user-friend.component';

describe('UserFriendComponent', () => {
  let component: UserFriendComponent;
  let fixture: ComponentFixture<UserFriendComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserFriendComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserFriendComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
