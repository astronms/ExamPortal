import { catchError, map } from 'rxjs/operators';
import { BehaviorSubject, Observable, throwError } from 'rxjs';

import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { UserModel } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private userSubject: BehaviorSubject<UserModel>;
  public user: Observable<UserModel>;

  constructor(private http: HttpClient, @Inject('BASE_URL')private baseUrl: string) { 
    this.userSubject = new BehaviorSubject<UserModel>(JSON.parse(localStorage.getItem('user')));
    this.user = this.userSubject.asObservable();
  }

  public login(credentials) : Observable<any> {
    return this.http.post<any>(this.baseUrl + 'api/auth/login', JSON.stringify(credentials), {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })})
      .pipe(map(user => {
        localStorage.setItem('user', JSON.stringify(user));
        this.userSubject.next(user);
        return true;
    }), catchError(this.handleError));
  }

  public get userValue(): UserModel {
    return this.userSubject.value;
  }

  public isUserAuthenticated() : boolean {
    if(this.userSubject.value)
      return true;

    return false;
  }

  /*public getUserRole() : UserRole {
    const token: string = localStorage.getItem("jwt");
    const decodedToken: { [key: string]: string }= jwt_decode(token);
    console.log(decodedToken);
    return UserRole.User;
  }*/
  
  public logOut() : void {
    localStorage.removeItem('user');
    this.userSubject.next(null);
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