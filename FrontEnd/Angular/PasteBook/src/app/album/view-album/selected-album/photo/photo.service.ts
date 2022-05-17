import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IPhoto } from './model/photo';
import { ConfigurationService } from 'src/app/configuration/configuration.service';

const API_ENDPOINT = "photos";

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class PhotoService {

  photo$ = new BehaviorSubject<IPhoto[]>([]);

  apiUrl: string = "";

  constructor(private http: HttpClient, 
    private configService: ConfigurationService) {

      this.apiUrl = this.configService.settings.apiUrl + API_ENDPOINT;
      console.log(this.apiUrl);

    }

    getAllPhotos(): Observable<IPhoto[]> {
      return this.http.get<IPhoto[]>(this.apiUrl);
    }
    
    getPhoto(id: number): Observable<IPhoto> {
      return this.http.get<IPhoto>(`${this.apiUrl}/${id}`);
    }
  
    addPhoto(entity: IPhoto): Observable<IPhoto> {
      // const formData = new FormData(); 
        
      // // Store form name as "file" with file data
      // formData.append('image', entity, entity.name);
        
      // // Make http post request over api
      // // with formData as req
      // console.log(formData)
      // return this.http.post(this.apiUrl, formData)

      console.log(entity)
      return this.http.post<IPhoto>(this.apiUrl, entity);
    }

    delete(id: number): Observable<IPhoto> {
      return this.http.delete<IPhoto>(`${this.apiUrl}/${id}`);
    }

}
