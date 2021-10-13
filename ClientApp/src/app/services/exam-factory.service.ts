import { catchError, map } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { SyncExamService } from './sync-exam.service';

@Injectable({
  providedIn: 'root'
})
export class ExamFactoryService {

    constructor(private http: HttpClient,  @Inject('BASE_URL')private baseUrl: string) { }

    startExam(examId: number) : Observable<boolean>{
        return this.http.get<boolean>(this.baseUrl + 'api/exam/start',{ params: {
            id: examId.toString()
        }}).pipe(map(result => {
            localStorage.setItem("pendingExam", "true");
            localStorage.setItem("examType", "sync"); //TODO: implement in backend to return examType and write it to the local store item. 
            return result;
        }), catchError(this.handleError));
    }

    getInstance() {
        //I know that this is not the best solution but it works. The better way will be to store object in field but this seems to be problematic. 
        //I need to dig in documentation how Dependency Injection works in Angular.
        let examType = localStorage.getItem("examType");
        if(examType == "sync")
            return new SyncExamService(this.http, this.baseUrl); 
        else 
            throw Error("Unknown or empty exam type");
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