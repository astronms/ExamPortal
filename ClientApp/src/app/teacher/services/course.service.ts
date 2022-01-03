import { DatePipe } from '@angular/common';
import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { ConstantPool } from '@angular/compiler';
import { Inject, Injectable, LOCALE_ID } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { CourseModel, CourseViewModel } from '../models/course.model';
import { NewCourse } from '../models/new-course.model';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(
    private http: HttpClient, 
    @Inject('BASE_URL')private baseUrl: string,
    @Inject(LOCALE_ID)private locale: string
  ) { }

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
      creationDate: new Date()
    };

    return this.http.post<NewCourse>(this.baseUrl + 'api/auth/Course', newCourse)
    .pipe(
      catchError(this.handleError)
    );
  }

  modifyCourse(course: CourseModel) : Observable<CourseModel>
  {
    return this.http.put<CourseModel>(this.baseUrl + 'api/auth/Course/' + course.courseId, course)
    .pipe(
      catchError(this.handleError)
    );
  }

  mapDataFromBackendToViewModel(course: CourseModel, index: number) : CourseViewModel
  {
    const datePipe: DatePipe = new DatePipe(this.locale);

    return <CourseViewModel>{
      id: course.courseId,
      no: index,
      title: course.name,
      creationDate: datePipe.transform(course.creationDate, 'dd-MMM-yyyy HH:mm'),
      studentsNumber: course.users.length
    };
  }

  mapArrayDataFromBackendToViewModel(data: CourseModel[]) : CourseViewModel[]
  {
    return data.map( (course, index) => this.mapDataFromBackendToViewModel(course, index + 1));
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
