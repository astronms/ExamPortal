import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { UserModel } from 'src/app/models/user.model';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL')private baseUrl: string
  ) {}

  getListOfStudents() : Observable<UserModel[]>
  {
    return this.http.get<UserModel[]>(this.baseUrl + 'api/auth/Student')
    .pipe(
      catchError(this.handleError)
    );
  }

  getStudent(userGuid: string) : Observable<UserModel>
  {
    return this.http.get<UserModel>(this.baseUrl + 'api/auth/Student/' + userGuid)
    .pipe(
      catchError(this.handleError)
    );
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
