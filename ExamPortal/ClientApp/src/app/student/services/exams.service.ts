import { catchError, map } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

import { ExamSessionModel } from '../../models/exam-session.model';

import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ExamsService {

  constructor(private http: HttpClient,  @Inject('BASE_URL')private baseUrl: string) { }

  getListOfExams() : Observable<ExamSessionModel[]>{
    return this.http.get<ExamSessionModel[]>(this.baseUrl + 'api/exam/getlist').pipe(catchError(this.handleError));
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