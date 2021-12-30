import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { ConstantPool } from '@angular/compiler';
import { Inject, Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { CourseModel } from '../models/course.model';
import { NewCourse } from '../models/new-course.model';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private http: HttpClient, @Inject('BASE_URL')private baseUrl: string) { }

  getListOfCourses() : Observable<CourseModel[]>
  {
    return this.http.get<CourseModel[]>(this.baseUrl + 'api/auth/Course')
    .pipe(
      catchError(this.handleError)
    );
  }

  addCourse(courseName: string) : Observable<NewCourse>
  {
    var newCourse: NewCourse = {
      name: courseName,
      creationDate: new Date()
    };

    return this.http.post<NewCourse>(this.baseUrl + 'api/auth/Course', newCourse)
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
