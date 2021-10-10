import { catchError, map } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

import { ExamModel } from '../models/exams.model';

import { Inject, Injectable, LOCALE_ID } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ExamService {

    constructor(private http: HttpClient,  @Inject('BASE_URL')private baseUrl: string) { }

    getListOfExams() : Observable<ExamModel[]>{
        return this.http.get<ExamModel[]>(this.baseUrl + 'api/exam/getlist').pipe(catchError(this.handleError));
    }

    startExam(examId: number) : Observable<boolean>{
        return this.http.get<boolean>(this.baseUrl + 'api/exam/start',{ params: {
            id: examId.toString()
        }}).pipe(map(result => {
            localStorage.setItem("pendingExam", "true");
            return result;
        }), catchError(this.handleError));
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