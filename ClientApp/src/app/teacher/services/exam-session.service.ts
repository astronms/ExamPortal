import { Injectable} from '@angular/core';
import { Observable } from 'rxjs';
import { ExamSessionModel } from 'src/app/models/exam-session.model';

@Injectable({
  providedIn: 'root'
})
export class ExamSessionService {

  constructor() { }

  getListOfExamSessions() : Observable<ExamSessionModel[]>
  {
    let date: Date = new Date();  
    var exams : ExamSessionModel[] = [];
    exams[0] = {
      sessionId: 0,
      name: "Exam1",
      startDate: new Date(),
      endDate: new Date(),
      courseId: 0,
      course: null
    };
    exams[1] = {
      sessionId: 1,
      name: "Exam2",
      startDate: new Date(),
      endDate: new Date(),
      courseId: 0,
      course: null
    };

    const obsUsingCreate = new Observable<ExamSessionModel[]>( observer => {
      observer.next(exams)
      observer.complete()
    })

    return obsUsingCreate;
  }
}
