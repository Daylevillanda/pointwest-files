import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Configuration } from './configuration';

@Injectable({
  providedIn: 'root'
})
export class ConfigurationService {
  settings: Configuration = new Configuration();

  constructor() { }

  getSettings(): Observable<Configuration> {
    return of(this.settings);
  }
}
