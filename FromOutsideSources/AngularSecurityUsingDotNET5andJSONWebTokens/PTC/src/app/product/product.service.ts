import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';

import { Product } from './product';
import { MessageService } from '../shared/messaging/message.service';
import { ProductSearch } from './product-search';
import { ConfigurationService } from '../shared/configuration/configuration.service';

const API_ENDPOINT = "product/";

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  apiUrl: string = "";

  constructor(private http: HttpClient,
    private msgService: MessageService,
    private configService: ConfigurationService) {
    this.apiUrl = this.configService.settings.apiUrl + API_ENDPOINT;
  }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUrl).pipe(
      catchError(
        this.handleError<Product[]>('getProducts',
          "Can't retrieve products.", []))
    );
  }

  search(search: ProductSearch): Observable<Product[]> {
    return this.http.post<Product[]>(this.apiUrl + "Search",
      search, httpOptions).pipe(
        catchError(this.handleError<Product[]>('search',
          'Error searching for products: '
          + JSON.stringify(search), []))
      );
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(this.apiUrl + id.toString()).pipe(
      catchError(
        this.handleError<Product>('getProduct',
          "Can't retrieve product: " + id.toString(),
          new Product()))
    );
  }

  addProduct(entity: Product): Observable<Product> {
    return this.http.post<Product>(this.apiUrl, entity,
      httpOptions).pipe(
        catchError(this.handleError<Product>('addProduct',
          'Error inserting a new product: '
          + JSON.stringify(entity),
          entity))
      );
  }

  updateProduct(entity: Product): Observable<any> {
    return this.http.put(this.apiUrl + entity.productId.toString(), entity, httpOptions).pipe(
      catchError(this.handleError<any>('updateProduct',
        'Error updating product: ' + JSON.stringify(entity),
        entity))
    );
  }

  deleteProduct(id: number): Observable<Product> {
    return this.http.delete<Product>(this.apiUrl + id.toString(),
      httpOptions).pipe(
        catchError(this.handleError<Product>('deleteProduct',
          'Error deleting product: ' + id.toString()))
      );
  }

  private handleError<T>(operation = 'operation', msg = '', result?: T) {
    // Add error messages to message service
    return (error: any): Observable<T> => {
      // Clear any old messages
      this.msgService.clearExceptionMessages();
      this.msgService.clearValidationMessages();

      msg = "Status Code: " + error.status + " - " + msg || "";

      console.log(msg + " " + JSON.stringify(error));

      // Set the last exception generated
      this.msgService.lastException = error;

      switch (error.status) {
        case 400:  // Model State Error
          if (error.error) {
            // Add all error messages to the validationMessages list
            Object.keys(error.error.errors)
              .map(keyName => this.msgService
                .addValidationMessage(error.error.errors[keyName][0]));
            // Reverse the array so error messages come out in the right order
            this.msgService.validationMessages = this.msgService.validationMessages.reverse();
          }
          break;
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
