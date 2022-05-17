import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { UserFriendService } from './user-friend.service';
import { IUser_Friends } from './Model/user-friends';

@Component({
  selector: 'app-user-friend',
  templateUrl: './user-friend.component.html',
  styleUrls: ['./user-friend.component.scss']
})
export class UserFriendComponent implements OnInit {

  user_friend: IUser_Friends = {
    UserId: 1,
  FriendId: 3,
  Status: true
  }
  user_friend$: Observable<IUser_Friends[]> | undefined;

  constructor(private user_friendService: UserFriendService) { }

  ngOnInit(): void {
    this.user_friend$ = this.user_friendService.getAllUser_Friends();
  }

  addNewUser_Friend() {
    this.user_friendService.addFriend(this.user_friend).subscribe(user_friend => this.user_friend == user_friend);
    console.log("success");
  }
}