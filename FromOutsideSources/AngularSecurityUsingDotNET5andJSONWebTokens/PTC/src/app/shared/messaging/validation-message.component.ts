import { Component, OnInit } from '@angular/core';
import { MessageService } from './message.service';

@Component({
  selector: 'validation-message',
  templateUrl: './validation-message.component.html',
  styleUrls: ['./validation-message.component.css']
})
export class ValidationMessageComponent implements OnInit {
  messageService: MessageService;
  
  constructor(private msgService: MessageService) { 
    this.messageService = msgService;
  }

  ngOnInit(): void {
  }

}
