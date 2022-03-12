import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Inject, Injectable} from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { map, catchError, tap, } from 'rxjs/operators';
import { ExamResultModel } from 'src/app/models/exam-result-model';
import { UserModel } from 'src/app/models/user.model';
import { ExamSessionResultsModel } from '../models/exam-session-results.model';

@Injectable({
  providedIn: 'root'
})
export class ExamSessionResultService {

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL')private baseUrl: string
  ) { }

  getExamSessionUsersWithResults(examSessionGuid: string) : Observable<UserModel[]>
  {
    return this.http.get<ExamSessionResultsModel>(this.baseUrl + 'api/auth/Session/' + examSessionGuid + '/result')
    .pipe(
        map(examResults => examResults.usersScore.map(item => {
            item.user.score = item.score;
            item.user.maxScore = item.maxScore;
            return item.user;
        })),
      catchError(this.handleError)
    );
  }

  getExamSessionUserResult(examSessionGuid: string, userGuid: string) : Observable<ExamResultModel>
  {
    return this.http.get<ExamResultModel>(this.baseUrl + 'api/auth/Session/' + examSessionGuid + '/result/' + userGuid).pipe(
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
