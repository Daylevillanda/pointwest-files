import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Category } from './category';
import { ConfigurationService } from '../shared/configuration/configuration.service';
import { MessageService } from '../shared/messaging/message.service';

const API_ENDPOINT = "category/";

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  apiUrl:string = "";

  constructor(private http: HttpClient,
    private msgService: MessageService,
    private configService: ConfigurationService) {
    this.apiUrl = this.configService.settings.apiUrl + API_ENDPOINT;
  }
  
  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.apiUrl).pipe(
      catchError(
        this.handleError<Category[]>('getCategories',
          "Can't retrieve categories.", []))
    );
  }

  private handleError<T>(operation = 'operation', msg = '', result?: T) {
    // Add error messages to message service
    return (error: any): Observable<T> => {
      // Clear any old messages
      this.msgService.clearExceptionMessages();

      msg = "Status Code: " + error.status + " - " + msg || "";

      console.log(msg + " " + JSON.stringify(error));

      // Set the last exception generated
      this.msgService.lastException = error;

      switch (error.status) {
        case 404:
          this.msgService.addExceptionMessage(msg);
          break;
        case 500:
          this.msgService.addExceptionMessage(error.error);
          break;
        case 0:
          this.msgService.addExceptionMessage(
            "Unknown error, check to make sure the Web API URL can be reached." + " - ERROR: " + JSON.stringify(error));
          break;
        default:
          this.msgService.addException(error);
          break;
      }

      // Return default configuration values
      return of(result as T);
    };
  }
}
