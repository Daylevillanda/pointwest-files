import { Component, OnInit } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { IComments } from './Model/comments';
import { CommentService } from './comment.service';
import { NgForm } from '@angular/forms';
//try lang
import { IPost } from 'src/app/user/Model/users';
import { PostService } from '../post.service';

@Component({
  selector: 'app-comment',
  templateUrl: './comment.component.html',
  styleUrls: ['./comment.component.scss']
})
export class CommentComponent implements OnInit {

  newComment: IComments = {
    PostId: 4,
    UserId: 2,
    CommentContent: ''
  };

  commentText: any[];

  comments$: Observable<IComments[]> | undefined;

  //dagdag
  postText: any[];

  constructor(private commentService: CommentService, private postService: PostService) {
    this.commentText = [];
    //
    this.postText = [];
   }

  ngOnInit(): void {
    this.comments$ = this.commentService.getComments();
  }

  commentOnClick(){
    const data = {
      PostId : this.newComment.PostId,
      UserId : this.newComment.UserId,
      CommentContent: this.newComment.CommentContent
    };
    this.commentService.addComments(this.newComment).subscribe(newComment => this.newComment == newComment);
    console.log(this.newComment);
  }

  onSubmit(f: NgForm): void{
    let renderComment = f.value.renderComment;
    this.commentText.push({
      'renderComment': renderComment
    })
  }

}
