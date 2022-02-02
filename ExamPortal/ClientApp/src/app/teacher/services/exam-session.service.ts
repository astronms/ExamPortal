import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Inject, Injectable} from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { ExamSessionModel } from 'src/app/models/exam-session.model';
import { CourseModel } from '../models/course.model';

@Injectable({
  providedIn: 'root'
})
export class ExamSessionService {

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL')private baseUrl: string
  ) { }

  getListOfExamSessions() : Observable<ExamSessionModel[]>
  {
    return this.http.get<ExamSessionModel[]>(this.baseUrl + 'api/auth/Session')
    .pipe(
      map(result => {
        result.forEach(session => {
          this.http.get<CourseModel>(this.baseUrl + 'api/auth/Course/' + session.courseId).subscribe(course => {
            session.course = course;
          });
        });
        return result;
      }),
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
