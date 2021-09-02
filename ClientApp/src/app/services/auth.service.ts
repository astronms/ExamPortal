import { catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { __core_private_testing_placeholder__ } from '@angular/core/testing';

@Injectable()
export class AuthService {

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService,) { }

  login(credentials) : Observable<any> {
    return this.http.post("http://localhost:5000/api/auth/login", JSON.stringify(credentials), {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).pipe(
      catchError(this.handleError)
    );
  }

  isUserAuthenticated() {
    const token: string = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token)) {
      return true;
    }
    else {
      return false;
    }
  }
  
  public logOut = () => {
    localStorage.removeItem("jwt");
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('An error occurred:', error.error);
    } else {
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    return throwError(
      'Something bad happened; please try again later.');
  }
}
