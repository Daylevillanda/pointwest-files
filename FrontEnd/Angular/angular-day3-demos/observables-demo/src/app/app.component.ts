import { Component, OnDestroy, OnInit } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { SubjectService } from './subject.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, OnDestroy {

  subject: SubjectService;
  timer$!: Observable<number>;
  value = 0;
  subscription!: Subscription;
  products: any = [];
  
  constructor(subject: SubjectService) {
    this.subject = subject;
  }

  ngOnInit(): void {
    // this.timer$ = this.subject.createTimer();
    this.subscription = this.timer$.subscribe(message => {
      this.value = message;
    });

    // bilis bula bilis linis
    this.subject.getProducts().subscribe(products => {
      this.products = products;
    });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  changeName() {
    const names = [
      'Tzuyu', 'Sana', 'Mina', 'Jihyo', 'Chaeyoung',
      'Dahyun', 'Momo', 'Nayeon', 'Jeongyeon'
    ];
    this.subject.setName(names[Math.floor(Math.random() * names.length)]);
  }

}
