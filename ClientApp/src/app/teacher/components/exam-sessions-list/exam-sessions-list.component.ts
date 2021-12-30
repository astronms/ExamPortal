import { Component, OnInit } from '@angular/core';
import { ExamViewModel } from 'src/app/models/exam.model';
import { TableActionsModel } from 'src/app/models/table-actions.model';
import { ExamSessionService } from '../../services/exam-session.service';

@Component({
  selector: 'app-exam-sessions-list',
  templateUrl: './exam-sessions-list.component.html',
  styleUrls: ['./exam-sessions-list.component.css']
})
export class ExamSessionsListComponent implements OnInit {

  public examSessions: ExamViewModel[];
  public displayedColumns: string[] = ['id', 'title', 'duration', 'questionsNumber', 'startDate', 'available', 'actions'];
  public teacherActions: TableActionsModel[] = [
    {actionType: "description", tooltip: "Zobacz", url: "/teacher/view-exam" },
    {actionType: "edit", tooltip: "Edytuj", url: "\\" },
    {actionType: "delete", tooltip: "Kasuj", url: "\\" }
  ];


  constructor(private examSessionService: ExamSessionService) { }

  ngOnInit() {
    
    this.examSessionService.getListOfExamSessions().subscribe(result => {
      this.examSessions = this.examSessionService.mapArrayDataFromBackendToViewModel(result);
    });
  }

}
