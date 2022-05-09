import { Component, OnInit } from '@angular/core';
import { MessageService } from './message.service';

@Component({
  selector: 'exception-message',
  templateUrl: './exception-message.component.html',
  styleUrls: ['./exception-message.component.css']
})
export class ExceptionMessageComponent implements OnInit {
  messageService: MessageService;

  constructor(private msgService: MessageService) { 
    this.messageService = msgService;
  }

  ngOnInit(): void {
  }

}
