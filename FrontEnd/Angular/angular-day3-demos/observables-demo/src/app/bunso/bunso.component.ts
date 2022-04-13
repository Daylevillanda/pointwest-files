import { Component, OnInit } from '@angular/core';
import { SubjectService } from '../subject.service';

@Component({
  selector: 'app-bunso',
  templateUrl: './bunso.component.html',
  styleUrls: ['./bunso.component.css']
})
export class BunsoComponent implements OnInit {

  subject: SubjectService;
  name!: string;

  constructor(subject: SubjectService) {
    this.subject = subject;
  }

  ngOnInit(): void {
    this.subject.name$.subscribe(name => {
      this.name = name.toUpperCase();
    });
  }

}
