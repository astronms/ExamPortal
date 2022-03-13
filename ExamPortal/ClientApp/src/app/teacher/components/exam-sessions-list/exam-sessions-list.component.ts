import { Component, OnInit } from '@angular/core';
import { ExamSessionModel } from 'src/app/models/exam-session.model';
import { TableActionsModel } from 'src/app/models/table-actions.model';
import { ExamSessionService } from '../../services/exam-session.service';

@Component({
  selector: 'app-exam-sessions-list',
  templateUrl: './exam-sessions-list.component.html',
  styleUrls: ['./exam-sessions-list.component.css']
})
export class ExamSessionsListComponent implements OnInit {

  public examSessions: ExamSessionModel[];
  public displayedColumns: string[] = ['index', 'name', 'startDate', 'endDate', 'actions'];
  public teacherActions: TableActionsModel[] = [
    {actionType: "description", tooltip: "Zobacz", url: "/teacher/view-exam" },
    {actionType: "edit", tooltip: "Edytuj", url: "/teacher/edit-exam" },
    {actionType: "delete", tooltip: "Kasuj", url: "/teacher/delete-exam" }
  ];


  constructor(
    private examSessionService: ExamSessionService
  ) { }

  ngOnInit() {
    this.examSessionService.getListOfExamSessions().subscribe(result => {
      this.examSessions = result;
    });
  }

}
