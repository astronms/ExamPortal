import { Component, Inject, LOCALE_ID, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ExamsService } from '../../services/exams.service';
import { ExamSessionModel } from '../../../models/exam-session.model';
import { TableActionsModel } from 'src/app/models/table-actions.model';

@Component({
  selector: 'exams',
  templateUrl: './exams.component.html',
  styleUrls: []
})
export class ExamsComponent implements OnInit {

  public examSessions: ExamSessionModel[];
  public displayedColumns: string[] = ['index', 'name', 'startDate', 'endDate', 'actions'];
  public studentActions: TableActionsModel[] = [
    {actionType: "edit", tooltip: "Rozwiąż", click: this.startExam },
    {actionType: "description", tooltip: "Zobacz", url: "//" }
  ];

  constructor(
    private examsService: ExamsService, 
    private router: Router
  ) { }

  ngOnInit() {

    this.examsService.getListOfExamSessions().subscribe(result => {
      this.examSessions = result;
    });
  }

  startExam(examSessionId: number)
  {
    this.router.navigate(["/exam/", examSessionId]); 
  }
  
}
