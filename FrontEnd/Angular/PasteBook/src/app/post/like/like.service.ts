import { Injectable } from '@angular/core';
import { Observable, of} from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ILikes } from './Model/likes';
import { ConfigurationService } from 'src/app/configuration/configuration.service';

const API_ENDPOINT = "likes";

@Injectable({
  providedIn: 'root'
})
export class LikeService {

  apiUrl: string = "";

  constructor(private http: HttpClient, 
    private configService: ConfigurationService) {
      this.apiUrl = this.configService.settings.apiUrl + API_ENDPOINT;
      console.log(this.apiUrl);
    }

    getLikes(): Observable<ILikes[]> {
      return this.http.get<ILikes[]>(this.apiUrl);
    } 

    addLikes(entity: ILikes): Observable<ILikes> {
      return this.http.post<ILikes>(this.apiUrl, entity);
    }
}
