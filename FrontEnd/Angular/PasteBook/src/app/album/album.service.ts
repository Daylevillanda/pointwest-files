import { Injectable } from '@angular/core';
import { BehaviorSubject, catchError, Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ConfigurationService } from '../configuration/configuration.service';
import { IAlbum } from './model/album';

const API_ENDPOINT = "albums";

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class AlbumService {

  album$ = new BehaviorSubject<IAlbum[]>([]);

  apiUrl: string = "";

  constructor(private http: HttpClient, 
    private configService: ConfigurationService) {

      this.apiUrl = this.configService.settings.apiUrl + API_ENDPOINT;
      console.log(this.apiUrl);

    }

  getAllAlbums(): Observable<IAlbum[]> {
    return this.http.get<IAlbum[]>(this.apiUrl);
  }
  
  getAlbum(id: number): Observable<IAlbum> {
    return this.http.get<IAlbum>(`${this.apiUrl}/${id}`);
  }

  addAlbum(entity: IAlbum): Observable<IAlbum> {
    console.log(entity);
    return this.http.post<IAlbum>(this.apiUrl, entity);
  }

  update(id: number, entity: IAlbum): Observable<IAlbum> {
    return this.http.put<IAlbum>(`${this.apiUrl}/${id}`, entity);
  }
  delete(id: number): Observable<IAlbum> {
    return this.http.delete<IAlbum>(`${this.apiUrl}/${id}`);
  }
}
