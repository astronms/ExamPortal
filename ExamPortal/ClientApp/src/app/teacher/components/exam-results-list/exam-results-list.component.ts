import { Component, OnInit } from '@angular/core';
import { ExamSessionModel } from 'src/app/models/exam-session.model';
import { TableActionsModel } from 'src/app/models/table-actions.model';
import { ExamSessionService } from '../../services/exam-session.service';

@Component({
  selector: 'app-exam-results-list',
  templateUrl: './exam-results-list.component.html',
  styleUrls: ['./exam-results-list.component.css']
})
export class ExamResultsListComponent implements OnInit {

  public examSessions: ExamSessionModel[];
  public displayedColumns: string[] = ['index', 'name', 'startDate', 'endDate', 'participation', 'actions'];
  public teacherActions: TableActionsModel[] = [
    {actionType: "arrow_downward", tooltip: "Pobierz odpowiedzi" },
    {actionType: "arrow_upward", tooltip: "Prześlij wyniki", },
    {actionType: "bar_chart", tooltip: "Zobacz wyniki", url: "/" }
  ];

  constructor(
    private examSessionService: ExamSessionService
  ) { }

  ngOnInit(): void {
    this.examSessionService.getFinishedExamSessions().subscribe(result => {
      this.examSessions = result;
    });
  }

  onActionClicked(event) : void
  {
    if(event.action == "arrow_downward")
    {
      this.downloadAnswers(event.id);
    }
    else if(event.action == "arrow_upward")
    {
      this.openUploadFileDialog();
    }
  }

  private downloadAnswers(guid: string)
  {
    this.examSessionService.downloadSessionAnswers(guid).subscribe(
      result => {
        this.examSessionService.getExamSession(guid).subscribe(session => {
          const a = document.createElement('a')
          const objectUrl = URL.createObjectURL(result)
          a.href = objectUrl
          a.download = session.name.replace(' ', '_') + '.xml';
          a.click();
          URL.revokeObjectURL(objectUrl);
        })
      }
    );
  }

  private openUploadFileDialog()
  {
    console.log("Here will be uload :)");
  }

}
