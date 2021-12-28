import { DatePipe } from '@angular/common';
import { Component, Inject, LOCALE_ID, OnInit } from '@angular/core';
import { ExamModel } from 'src/app/models/exam.model';
import { ExamSessionService } from '../../services/exam-session.service';

@Component({
  selector: 'app-exam-sessions-list',
  templateUrl: './exam-sessions-list.component.html',
  styleUrls: ['./exam-sessions-list.component.css']
})
export class ExamSessionsListComponent implements OnInit {

  public examSessions: ExamModel[];
  public displayedColumns: string[] = ['id', 'title', 'duration', 'questionsNumber', 'startDate', 'available', 'actions'];

  constructor(private examSessionService: ExamSessionService, @Inject(LOCALE_ID)private locale: string) { }

  ngOnInit() {

    const datepipe: DatePipe = new DatePipe(this.locale);
    
    this.examSessionService.getListOfExamSessions().subscribe(result => {
      result.forEach( exam => {
        exam.startDate =  datepipe.transform(exam.startDate, 'dd-MMM-yyyy HH:mm');
      });

      this.examSessions = result;
    });

    console.log(this.examSessions)
  }

}
