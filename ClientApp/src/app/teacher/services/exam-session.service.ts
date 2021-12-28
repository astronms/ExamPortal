import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ExamModel } from 'src/app/models/exam.model';

@Injectable({
  providedIn: 'root'
})
export class ExamSessionService {

  constructor() { }

  getListOfExamSessions() : Observable<ExamModel[]>
  {
    let date: Date = new Date();  
    var exams : ExamModel[] = [];
    exams[0] = {id: 0, title: "asass", duration: 200, questionsNumber: 10, startDate: date.toString(), available: true };
    exams[1] = {id: 0, title: "asass", duration: 200, questionsNumber: 10, startDate: date.toString(), available: true };

    const obsUsingCreate = new Observable<ExamModel[]>( observer => {
      observer.next(exams)
      observer.complete()
    })

    return obsUsingCreate;
  }
}
