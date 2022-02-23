import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { UserModel } from 'src/app/models/user.model';
import { CourseModel } from '../models/course.model';
import { NewCourse } from '../models/new-course.model';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL')private baseUrl: string
  ) {}

  getListOfCourses() : Observable<CourseModel[]>
  {
    return this.http.get<CourseModel[]>(this.baseUrl + 'api/auth/Course')
    .pipe(
      catchError(this.handleError)
    );
  }

  getCourse(guid: string) : Observable<CourseModel>
  {
    return this.http.get<CourseModel>(this.baseUrl + 'api/auth/Course/' + guid)
    .pipe(
      catchError(this.handleError)
    );
  }

  addCourse(course: CourseModel) : Observable<NewCourse>
  {
    var newCourse: NewCourse = {
      name: course.name,
      creationDate: new Date(),
      usersId: []
    };

    course.users.forEach(el => {
      newCourse.usersId.push(el.id);
    });

    return this.http.post<NewCourse>(this.baseUrl + 'api/auth/Course', newCourse)
    .pipe(
      catchError(this.handleError)
    );
  }

  deleteCourse(course: CourseModel) : Observable<any>
  {
    return this.http.delete<boolean>(this.baseUrl + 'api/auth/Course/' + course.courseId)
    .pipe(
      catchError(this.handleError)
    );
  }

  modifyCourse(course: CourseModel) : Observable<CourseModel>
  {
    var newCourse: NewCourse = {
      name: course.name,
      creationDate: course.creationDate,
      usersId: []
    };

    course.users.forEach(el => {
      newCourse.usersId.push(el.id);
    });

    return this.http.put<CourseModel>(this.baseUrl + 'api/auth/Course/' + course.courseId, newCourse)
    .pipe(
      catchError(this.handleError)
    );
  }

  getListOfStudents() : Observable<UserModel[]>
  {
    return this.http.get<UserModel[]>(this.baseUrl + 'api/auth/Student')
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
