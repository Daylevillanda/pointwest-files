import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ValidIdGuard implements CanActivate {
  constructor(private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      let redirect: string = route.data["redirectTo"];
      let ret: boolean = true;
      let id: any = route.params.id;
    
      if (isNaN(id) || id == -1) {
        this.router.navigate([redirect]);
        ret = false;
      }
    
      return ret;  
  }
  
}
