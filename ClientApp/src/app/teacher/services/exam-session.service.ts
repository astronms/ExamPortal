import { DatePipe } from '@angular/common';
import { Inject, Injectable, LOCALE_ID } from '@angular/core';
import { Observable } from 'rxjs';
import { ExamModel, ExamViewModel } from 'src/app/models/exam.model';

@Injectable({
  providedIn: 'root'
})
export class ExamSessionService {

  constructor(@Inject(LOCALE_ID)private locale: string) { }

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

  mapDataFromBackendToViewModel(exam: ExamModel, index: number) : ExamViewModel
  {
    const datePipe: DatePipe = new DatePipe(this.locale);

    return  <ExamViewModel>{
      no: index,
      title: exam.title,
      duration: exam.duration,
      questionsNumber: exam.questionsNumber,
      startDate: datePipe.transform(exam.startDate, 'dd-MMM-yyyy HH:mm'),
      available: exam.available
    };
  }

  mapArrayDataFromBackendToViewModel(exams: ExamModel[]) : ExamViewModel[]
  {
    return exams.map( (exam, index) => this.mapDataFromBackendToViewModel(exam, index + 1));
  } 
}
