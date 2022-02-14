import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ExamSessionModel } from 'src/app/models/exam-session.model';

@Component({
  selector: 'app-start-exam-dialog',
  templateUrl: './start-exam-dialog.component.html'
})
export class StartExamDialogComponent {

  constructor(
    public dialogRef: MatDialogRef<StartExamDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public examSession: ExamSessionModel,
  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
