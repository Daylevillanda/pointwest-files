import { Injectable } from '@angular/core';
import { Observable, of} from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IPosts } from '../Model/posts';
import { ConfigurationService } from 'src/app/configuration/configuration.service';

const API_ENDPOINT = "posts";

@Injectable({
  providedIn: 'root'
})
export class PostdirectoryService {

  _url= "https://localhost:44368/posts";

  apiUrl: string = "";

  constructor(private http: HttpClient, 
    private configService: ConfigurationService) {
      this.apiUrl = this.configService.settings.apiUrl + API_ENDPOINT;
      console.log(this.apiUrl);
    }
    
    getPosts(): Observable<IPosts[]> {
      return this.http.get<IPosts[]>(this.apiUrl);
    } 
}
