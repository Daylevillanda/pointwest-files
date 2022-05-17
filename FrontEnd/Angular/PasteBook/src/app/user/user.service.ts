import { Injectable } from '@angular/core';
import { catchError, Observable, of, tap } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IAlbum, IPost, IUsers } from './Model/users';
import { ConfigurationService } from '../configuration/configuration.service';

const API_ENDPOINT = "users";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  apiUrl: string = "";

  constructor(private http: HttpClient, 
    private configService: ConfigurationService) {

      this.apiUrl = this.configService.settings.apiUrl + API_ENDPOINT;
      console.log(this.apiUrl);

    }
  users$ = this.http.get<IUsers[]>(this.apiUrl);

  getUsers(): Observable<IUsers[]> {
    return this.http.get<IUsers[]>(this.apiUrl);
  }

}
// import { Injectable } from '@angular/core';
// import { catchError, Observable, of, tap } from 'rxjs';
// import { HttpClient, HttpHeaders } from '@angular/common/http';
// import { IAlbum, IPost, IUsers } from './Model/users';
// import { ConfigurationService } from '../configuration/configuration.service';

// const API_ENDPOINT = "users";

// const httpOptions = {
//   headers: new HttpHeaders({
//     'Content-Type': 'application/json'
//   })
// };

// @Injectable({
//   providedIn: 'root'
// })
// export class UserService {

//   apiUrl: string = "";

//   constructor(private http: HttpClient, 
//     private configService: ConfigurationService) {

//       this.apiUrl = this.configService.settings.apiUrl + API_ENDPOINT;
//       console.log(this.apiUrl);

//     }
//   getUsers(): Observable<IUsers[]> {
//     return this.http.get<IUsers[]>(this.apiUrl);
//   }

//   postPost(entity: IPost): Observable<IPost> {
//     return this.http.post<IPost>(this.configService.settings.apiUrl + 'posts', entity, httpOptions);
//   }

//   getPostById(): Observable<IAlbum> {
//     return this.http.get<IAlbum>(this.configService.settings.apiUrl + 'albums/1', httpOptions)
//     .pipe(
//       tap(response => console.log(response))
//     );
//   }

// }

// ///samples of CRUD
// // addProduct(entity: Product): Observable<Product> {
// //   return this.http.post<Product>(this.apiUrl, entity,
// //     httpOptions).pipe(
// //       catchError(this.handleError<Product>('addProduct',
// //         'Error inserting a new product: '
// //         + JSON.stringify(entity),
// //         entity))
// //     );
// // }

// // updateProduct(entity: Product): Observable<any> {
// //   return this.http.put(this.apiUrl + entity.productId.toString(), entity, httpOptions).pipe(
// //     catchError(this.handleError<any>('updateProduct',
// //       'Error updating product: ' + JSON.stringify(entity),
// //       entity))
// //   );
// // }

// // deleteProduct(id: number): Observable<Product> {
// //   return this.http.delete<Product>(this.apiUrl + id.toString(),
// //     httpOptions).pipe(
// //       catchError(this.handleError<Product>('deleteProduct',
// //         'Error deleting product: ' + id.toString()))
// //     );
// // }
