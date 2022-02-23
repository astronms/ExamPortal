import { Component, EventEmitter, Inject, LOCALE_ID, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ExamsService } from '../../services/exams.service';
import { ExamSessionModel } from '../../../models/exam-session.model';
import { TableActionsModel } from 'src/app/models/table-actions.model';
import { SyncExamService } from '../../services/sync-exam.service';
import { MatDialog } from '@angular/material/dialog';
import { StartExamDialogComponent } from '../start-exam-dialog/start-exam-dialog.component';
import { start } from 'repl';

@Component({
  selector: 'app-exams',
  templateUrl: './exams.component.html',
  styleUrls: []
})
export class ExamsComponent implements OnInit {

  public examSessions: ExamSessionModel[];
  public displayedColumns: string[] = ['index', 'name', 'startDate', 'endDate', 'actions'];
  public studentActions: TableActionsModel[] = [
    {actionType: "edit", tooltip: "Rozwiąż"},
    {actionType: "description", tooltip: "Zobacz", url: "//" }
  ];

  constructor(
    private examsService: ExamsService, 
    private examService: SyncExamService,
    public dialog: MatDialog,
    private router: Router
  ) { }

  ngOnInit() {
    this.examsService.getListOfExamSessions().subscribe(result => {
      this.examSessions = result;
    });
  }

  onActionClicked(event) : void
  {
    if(event.action == "edit")
    {
      this.examService.getExamData(event.id).subscribe(result => {
        const dialogRef = this.dialog.open(StartExamDialogComponent, {
          width: '500px',
          data: result,
        });
  
        dialogRef.afterClosed().subscribe(result => {
          if(result)
            this.startExam(event.id);
        });  
      }, err => {
        const dialogRef = this.dialog.open(StartExamDialogComponent, {
          width: '500px',
          data: null,
        });
      });
    }
  }

  private startExam(examSessionId: number) : void
  {
    this.router.navigate(["/student/exam/", examSessionId]); 
  }
  
}
