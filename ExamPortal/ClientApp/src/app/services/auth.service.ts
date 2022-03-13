import { catchError, map } from 'rxjs/operators';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { RoleEnum } from '../enums/role.enum';
import { UserModel } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private userSubject: BehaviorSubject<UserModel>;
  public user: Observable<UserModel>;

  constructor(private http: HttpClient, @Inject('BASE_URL')private baseUrl: string, private jwtHelper: JwtHelperService) { 
    this.userSubject = new BehaviorSubject<UserModel>(JSON.parse(localStorage.getItem('user')));
    this.user = this.userSubject.asObservable();
  }

  public login(credentials) : Observable<any> {
    return this.http.post<any>(this.baseUrl + 'api/Account/login', JSON.stringify(credentials), {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })})
      .pipe(map(result => {
        var data = this.jwtHelper.decodeToken(result.token);
        var user: UserModel = {
          email: data.Name,
          firstName: data.FirstName,
          lastName: data.LastName,
          role: data.Role,
          token: result.token
        }
        localStorage.setItem('user', JSON.stringify(user));
        this.userSubject.next(user); 
        
        return this.http.get<UserModel>(this.baseUrl + 'api/Account/info').subscribe(result => { //get full user data. In case when we receive failure we will still have partially data.
          result.role = user.role;
          result.token = user.token;
          localStorage.setItem('user', JSON.stringify(result));
          this.userSubject.next(result);
          return true;
        }, err => this.handleError(err))
    }), catchError(this.handleError));
  }

  public registerUser(user: UserModel) : Observable<UserModel>
  {
    return this.http.post<UserModel>(this.baseUrl + 'api/Account/register', user)
    .pipe(
      catchError(this.handleError)
    );
  }

  public registerTeacher(user: UserModel) : Observable<UserModel>
  {
    return this.http.post<UserModel>(this.baseUrl + 'api/Admin/AdminRegister', user)
    .pipe(
      catchError(this.handleError)
    );
  }

  public get userValue(): UserModel {
    return this.userSubject.value;
  }

  public isUserAuthenticated() : boolean {
    if(this.userSubject.value)
      if(!this.jwtHelper.isTokenExpired(this.userSubject.value.token))
        return true;

    return false;
  }

  public get userRole() : RoleEnum | null {
    if(this.userValue)
      return this.userValue.role;
    else
      return null;
  }

  public changePassword(currentPass: string, pass: string) : any
  {
    return this.http.put<any>(this.baseUrl + 'api/Account/updatePassword', {
      password: pass,
      currentPassword: currentPass
    })
    .pipe(
      catchError(this.handleError)
    );
  }
  
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