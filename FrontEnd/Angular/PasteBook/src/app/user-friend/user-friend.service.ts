import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IUser_Friends } from './Model/user-friends';
import { ConfigurationService } from '../configuration/configuration.service';

const API_ENDPOINT = "user-friends";

@Injectable({
  providedIn: 'root'
})
export class UserFriendService {
  api = "https://localhost:44368/"
  apiUrl: string = "";

  constructor(private http: HttpClient, 
    private configService: ConfigurationService) {
      this.apiUrl = this.configService.settings.apiUrl + API_ENDPOINT;
      console.log(this.apiUrl);
    }

    getAllUser_Friends(): Observable<IUser_Friends[]> {  
      return this.http.get<IUser_Friends[]>(this.apiUrl);  
    } 

    addFriend(entity: IUser_Friends): Observable<IUser_Friends> {  
      console.log(entity);
      return this.http.post<IUser_Friends>(this.apiUrl, entity);  
    } 
}
