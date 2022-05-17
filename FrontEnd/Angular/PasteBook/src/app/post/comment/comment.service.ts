import { Injectable } from '@angular/core';
import { Observable, of} from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IComments } from './Model/comments';
import { ConfigurationService } from 'src/app/configuration/configuration.service';

const API_ENDPOINT = "comments";

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  apiUrl: string = "";

  constructor(private http: HttpClient, 
    private configService: ConfigurationService) {
      this.apiUrl = this.configService.settings.apiUrl + API_ENDPOINT;
      console.log(this.apiUrl);
    }

    getComments(): Observable<IComments[]> {
      return this.http.get<IComments[]>(this.apiUrl);
    } 

    addComments(entity: IComments): Observable<IComments> {
      return this.http.post<IComments>(this.apiUrl, entity);
    }
}
