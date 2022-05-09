import { Component, OnInit } from '@angular/core';
import { ConfigurationService } from './shared/configuration/configuration.service';

@Component({
  selector: 'ptc-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'PTC';

  constructor(private configService: ConfigurationService) { }
  
  ngOnInit(): void {
    this.configService.getSettings().subscribe(
      settings => this.configService.settings = settings);
  }  
}
