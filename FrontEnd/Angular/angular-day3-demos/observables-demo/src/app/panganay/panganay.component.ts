import { Component, OnInit } from '@angular/core';
import { SubjectService } from '../subject.service';

@Component({
  selector: 'app-panganay',
  templateUrl: './panganay.component.html',
  styleUrls: ['./panganay.component.css']
})
export class PanganayComponent implements OnInit {

  subject: SubjectService;
  name!: string;

  constructor(subject: SubjectService) {
    this.subject = subject;
  }

  ngOnInit(): void {
    this.subject.name$.subscribe(name => {
      this.name = name;
    });
  }

}
