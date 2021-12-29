import { DatePipe } from '@angular/common';
import { Component, Inject, LOCALE_ID, OnInit } from '@angular/core';
import { ExamModel } from 'src/app/models/exam.model';
import { TableActionsModel } from 'src/app/models/table-actions.model';
import { ExamSessionService } from '../../services/exam-session.service';

@Component({
  selector: 'app-exam-sessions-list',
  templateUrl: './exam-sessions-list.component.html',
  styleUrls: ['./exam-sessions-list.component.css']
})
export class ExamSessionsListComponent implements OnInit {

  public examSessions: ExamModel[];
  public displayedColumns: string[] = ['id', 'title', 'duration', 'questionsNumber', 'startDate', 'available', 'actions'];
  public teacherActions: TableActionsModel[] = [
    {actionType: "description", tooltip: "Zobacz", url: "/teacher/view-exam" },
    {actionType: "edit", tooltip: "Edytuj", url: "\\" },
    {actionType: "delete", tooltip: "Kasuj", url: "\\" }
  ];


  constructor(private examSessionService: ExamSessionService, @Inject(LOCALE_ID)private locale: string) { }

  ngOnInit() {

    const datepipe: DatePipe = new DatePipe(this.locale);
    
    this.examSessionService.getListOfExamSessions().subscribe(result => {
      result.forEach( exam => {
        exam.startDate =  datepipe.transform(exam.startDate, 'dd-MMM-yyyy HH:mm');
      });

      this.examSessions = result;
    });
  }

}
