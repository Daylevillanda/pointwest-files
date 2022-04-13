import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-rating-stars',
  templateUrl: './rating-stars.component.html',
  styleUrls: ['./rating-stars.component.scss']
})
export class RatingStarsComponent {

  @Input() rating = 0;

  createArrayFromRating() {
    return new Array(this.rating);
  }

}
