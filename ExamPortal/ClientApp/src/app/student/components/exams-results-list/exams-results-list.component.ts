import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ExamSessionModel } from 'src/app/models/exam-session.model';
import { TableActionsModel } from 'src/app/models/table-actions.model';
import { ExamsService } from '../../services/exams.service';

@Component({
  selector: 'app-exams-results-list',
  templateUrl: './exams-results-list.component.html',
  styleUrls: ['./exams-results-list.component.css']
})
export class ExamsResultsListComponent implements OnInit {

  public examSessionsResults: ExamSessionModel[];
  public displayedColumns: string[] = ['index', 'name', 'startDate', 'endDate', 'result', 'actions'];
  public studentActions: TableActionsModel[] = [
    {actionType: "bar_chart", tooltip: "Zobacz"},
  ];

  constructor(
    private examsService: ExamsService, 
    private router: Router
  ) { }

  ngOnInit() {
    this.examsService.getListOfExamSessionsResults().subscribe(result => {
      this.examSessionsResults = result;
    });
  }

  onActionClicked(event) : void
  {
    if(event.action == "bar_chart")
    {
        let examResultId: number = null; 
        this.examSessionsResults.forEach(examResult => {
          if(examResult.sessionId == event.id)
            examResultId = examResult.sessionResultId;
        });
        this.router.navigate(['/student/exam-result/' + examResultId]);
    }
  }

}
