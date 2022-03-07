import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';

import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(
    private router: Router, 
    private authService: AuthService, 
    private jwtHelper: JwtHelperService
  ) {}

  canActivate(route: ActivatedRouteSnapshot) {
    const user = this.authService.userValue;
    if(user) {
      if(this.jwtHelper.isTokenExpired(user.token)) {
        this.router.navigate(["login"]);
        return false;
      }
      if (route.data.roles && !route.data.roles.includes(user.role)) {
        this.router.navigate(['/']);
        return false;
      }

      return true
    }
    this.router.navigate(["login"]);
    return false;
  }

}