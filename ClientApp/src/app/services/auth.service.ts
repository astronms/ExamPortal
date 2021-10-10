import { catchError, map } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private jwtHelper: JwtHelperService) { }

  login(credentials) : Observable<any> {
    let response = this.http.post("http://localhost:5000/api/auth/login", JSON.stringify(credentials))
      .pipe(map(response => {
        const token = (<any>response).token;
        if(response && token)
        {
          localStorage.setItem("jwt", token);
          return true;
        }
        return false;

    }), catchError(this.handleError));
    
    return response;
  }

  isUserAuthenticated() {
    const token: string = localStorage.getItem("jwt");
    if (token && !this.jwtHelper.isTokenExpired(token))
      return true;
    else
      return false;
  }
  
  public logOut() {
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
