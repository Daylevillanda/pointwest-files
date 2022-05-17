import { Injectable } from '@angular/core';
import { Observable, of} from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IPosts } from './Model/posts';
import { ConfigurationService } from '../configuration/configuration.service';

const API_ENDPOINT = "posts";

@Injectable({
  providedIn: 'root'
})
export class PostService {
  apiUrl: string = "";

  constructor(private http: HttpClient, 
    private configService: ConfigurationService) {
      this.apiUrl = this.configService.settings.apiUrl + API_ENDPOINT;
      console.log(this.apiUrl);
    }

    getPosts(): Observable<IPosts[]> {
      return this.http.get<IPosts[]>(this.apiUrl);
    } 

    // addPosts(entity: IPosts): Observable<IPosts> {
    //   return this.http.post<IPosts>(this.apiUrl, entity);
    // }

  }
