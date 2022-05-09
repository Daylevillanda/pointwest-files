import { Component, OnInit } from '@angular/core';
import { MessageService } from './message.service';

@Component({
  selector: 'info-message',
  templateUrl: './info-message.component.html',
  styleUrls: ['./info-message.component.css']
})
export class InfoMessageComponent implements OnInit {
  messageService: MessageService;

  constructor(private msgService: MessageService) { 
    this.messageService = msgService;
  }

  ngOnInit(): void {
  }

}
