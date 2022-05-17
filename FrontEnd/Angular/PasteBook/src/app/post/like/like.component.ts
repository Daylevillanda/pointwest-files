import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { ILikes } from './Model/likes';
import { LikeService } from './like.service';

@Component({
  selector: 'app-like',
  templateUrl: './like.component.html',
  styleUrls: ['./like.component.scss']
})
export class LikeComponent implements OnInit {

  newLike: ILikes = {
    PostId: 4,
    UserId: 2
  };

  @Input() numberOfLikes : number = 0;

  @Output()
  change: EventEmitter<number> = new EventEmitter<number>();

  likes$: Observable<ILikes[]> | undefined;

  constructor(private likeService: LikeService) {
   }

  ngOnInit(): void {
    this.likes$ = this.likeService.getLikes();
  }

  // likeOnClick(){
  //   this.likeService.addLikes(this.newLike).subscribe(newLike => this.newLike == newLike);
  //   console.log(this.newLike);
  // }

  likeButtonClick() {
    this.likeService.addLikes(this.newLike).subscribe(newLike => this.newLike == newLike);
    console.log(this.newLike);
    this.numberOfLikes++;
    this.change.emit(this.numberOfLikes);
  }
}
