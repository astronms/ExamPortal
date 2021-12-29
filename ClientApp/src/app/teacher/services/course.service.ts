import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CourseModel } from '../models/course.model';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor() { }

  getListOfCourses() : Observable<CourseModel[]>
  {
    let date: Date = new Date();  
    var courses : CourseModel[] = [
        {id: 0, title: "Kurs 1", creationDate: date.toString(), studentsNumber: 50},
        {id: 1, title: "Kurs 2", creationDate: date.toString(), studentsNumber: 90},
        {id: 2, title: "Kurs 5", creationDate: date.toString(), studentsNumber: 60}
    ];

    const obsUsingCreate = new Observable<CourseModel[]>( observer => {
      observer.next(courses)
      observer.complete()
    })

    return obsUsingCreate;
  }
}
