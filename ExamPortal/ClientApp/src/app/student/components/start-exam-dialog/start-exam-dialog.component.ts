import { Component, Inject, Pipe, PipeTransform } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { PersonalExamInfoModel } from '../../models/personal-exam-info.model';

@Component({
  selector: 'app-start-exam-dialog',
  templateUrl: './start-exam-dialog.component.html',
  styleUrls: ['./start-exam-dialog.component.css']
})
export class StartExamDialogComponent {

  constructor(
    public dialogRef: MatDialogRef<StartExamDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public examData: PersonalExamInfoModel,
  ) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
