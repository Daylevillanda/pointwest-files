import { Injectable } from '@angular/core';
import { catchError, Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { IUser_Registrations } from './Model/user-registrations';
import { ConfigurationService } from '../configuration/configuration.service';

const API_ENDPOINT = "register";

@Injectable({
  providedIn: 'root'
})
export class UserRegistrationService {

  apiUrl: string = "";

  constructor(private http: HttpClient, 
    private configService: ConfigurationService) {

      this.apiUrl = this.configService.settings.apiUrl + API_ENDPOINT;
      console.log(this.apiUrl);

    }

    addUser(entity: IUser_Registrations): Observable<IUser_Registrations> {
      return this.http.post<IUser_Registrations>(this.apiUrl, entity);
    }

}
