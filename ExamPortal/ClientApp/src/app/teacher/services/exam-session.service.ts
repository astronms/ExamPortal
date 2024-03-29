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

  getExamSession(guid: string): Observable<ExamSessionModel>
  {
    return this.http.get<ExamSessionModel>(this.baseUrl + 'api/auth/Session/' + guid)
    .pipe(
      map(session => {
        this.http.get<CourseModel>(this.baseUrl + 'api/auth/Course/' + session.courseId).subscribe(course => {
          session.course = course;
        });
        return session;
      }),
      catchError(this.handleError)
    );
  }

  addExamSession(exam: ExamSessionModel, file: File) : Observable<any>
  {
    console.log(exam);
    const formData = new FormData();
    formData.append("File", file);
    formData.append("Name", exam.name);
    formData.append("StartDate", exam.startDate.toLocaleString());
    formData.append("EndDate", exam.endDate.toLocaleString());
    formData.append("CourseId", exam.courseId.toString());
    formData.append("Type", exam.type);
    return this.http.post(this.baseUrl + 'api/auth/Session', formData)
    .pipe(
      catchError(this.handleError)
    );
  }

  modifyExamSession(exam: ExamSessionModel, file: File) : Observable<any>
  {
    const formData = new FormData();
    formData.append("File", file);
    formData.append("Name", exam.name);
    formData.append("StartDate", exam.startDate.toLocaleString());
    formData.append("EndDate", exam.endDate.toLocaleString());
    formData.append("CourseId", exam.courseId.toString());
    formData.append("Type", exam.type);
    return this.http.put(this.baseUrl + 'api/auth/Session/' + exam.sessionId, formData)
    .pipe(
      catchError(this.handleError)
    );
  }

  deleteExamSession(exam: ExamSessionModel) : Observable<any>
  {
    return this.http.delete(this.baseUrl + 'api/auth/Session/' + exam.sessionId)
    .pipe(
      catchError(this.handleError)
    );
  }

  getFinishedExamSessions() : Observable<ExamSessionModel[]>
  {
    return this.http.get<ExamSessionModel[]>(this.baseUrl + 'api/auth/Session/answers-list')
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

  downloadSessionAnswers(guid: string) : Observable<Blob>
  { 
    return this.http.get(this.baseUrl + 'api/auth/Session/' + guid + '/answers', {responseType: 'blob'}).pipe(
      catchError(this.handleError)
    )
  }

  saveSessionResult(guid: string, file: File) : Observable<any>
  {
    const formData = new FormData();
    formData.append("resultFile", file, file.name);
    return this.http.post(this.baseUrl + 'api/auth/Session/' + guid + '/result', formData)
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
