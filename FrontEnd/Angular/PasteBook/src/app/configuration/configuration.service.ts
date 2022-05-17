import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Configuration } from './Model/configuration';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {

  settings: Configuration = new Configuration();

  constructor() { }

  getConfiguration(): Observable<Configuration> {
    return of(this.settings);
  }
  
}
