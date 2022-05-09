import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { AppUser } from 'src/app/security/app-user';
import { AppUserAuth } from 'src/app/security/app-user-auth';

@Injectable({
  providedIn: 'root'
})
export class SecurityService {
  securityObject: AppUserAuth = new AppUserAuth();
  constructor() { }
  login(entity: AppUser): Observable<AppUserAuth>{
    this.securityObject.userName = entity.userName;

    switch(entity.userName.toLowerCase()){
      case "psheriff":
        this.securityObject.isAuthenticated = true;
        this.securityObject.canAccessProducts = false;
        this.securityObject.canAccessCategories = false;
        this.securityObject.canAccessLogs = false;
        this.securityObject.canAccessSettings = false;
        this.securityObject.canAddProduct = false;
        this.securityObject.canEditProduct = false;
        this.securityObject.canDeleteProduct = false;
        break;
      case "bjones":
        this.securityObject.isAuthenticated = true;
        this.securityObject.canAccessLogs = false;
        this.securityObject.canAccessSettings = false;
        break;
      default:
        this.securityObject.userName = "Invalid User Name or Password";
        break;
    }
    return of(this.securityObject);
  }

  logout(): void {
    this.securityObject.init();
  }
}
