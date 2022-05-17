import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor(private authService: AuthService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {    
    if(this.authService.isLoggedIn()){
      let token = localStorage.getItem('token');
      const authRequest = request.clone({
        headers: request.headers.set('Authorization', 'Bearer ' + JSON.parse(token!))
        .set('Content-Type', 'application/json')
      });
      return next.handle(authRequest);
    }
    const authRequest = request.clone({
      setHeaders: {'Content-Type': 'application/json'}
    });
    return next.handle(authRequest);
  }
}
