import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Observable, pipe, tap } from 'rxjs';
import { IPosts } from '../Model/posts';
import { PostService } from '../post.service';
//merging like test
import { ILikes } from '../like/Model/likes';
import { LikeService } from '../like/like.service';
//merging comment test
import { IComments } from '../comment/Model/comments';
import { CommentService } from '../comment/comment.service';
import { HttpClient } from '@angular/common/http';
import { PostdirectoryService } from './postdirectory.service';

@Component({
  selector: 'app-postdirectory',
  templateUrl: './postdirectory.component.html',
  styleUrls: ['./postdirectory.component.scss']
})
export class PostdirectoryComponent implements OnInit {

  newLike: ILikes = {
    PostId: 4,
    UserId: 2
  };

  newComment: IComments = {
    PostId: 4,
    UserId: 2,
    CommentContent: ''
  };

  posts:IPosts|any;

  posts$: Observable<IPosts[]> | any;
  likes$: Observable<ILikes[]> | undefined;
  comments$: Observable<IComments[]> | undefined;

  @Input() numberOfLikes : number = 0;
  @Input() numberOfComments : number = 0;

  @Output()
  change: EventEmitter<number> = new EventEmitter<number>();

  commentText: any[];

  constructor(private postService: PostService, private likeService: LikeService, private commentService: CommentService, private http: HttpClient, private postDirectory: PostdirectoryService) {
    this.commentText = [];
    this.postDirectory.getPosts().subscribe((data)=>{this.posts=data})
   }

  ngOnInit(): void {
    this.posts$ = this.postService.getPosts(); 
    //try lang
    this.likes$ = this.likeService.getLikes();
    //comment try
    this.comments$ = this.commentService.getComments();
  }

  likeButtonClick() {
    this.likeService.addLikes(this.newLike).subscribe(newLike => this.newLike == newLike);
    console.log(this.newLike);
    this.numberOfLikes++;
    this.change.emit(this.numberOfLikes);   
  }

  //////////////
  commentOnClick(){
    const data = {
      PostId : this.newComment.PostId,
      UserId : this.newComment.UserId,
      CommentContent: this.newComment.CommentContent
    };
    this.commentService.addComments(this.newComment).subscribe(newComment => this.newComment == newComment);
    console.log(this.newComment);
    this.numberOfComments++;
    this.change.emit(this.numberOfComments);   
  }

  onSubmitOfComment(f: NgForm): void{
    let renderComment = f.value.renderComment;
    this.commentText.push({
      'renderComment': renderComment
    })
  }
  //////////////

  
}
