import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ThemePalette } from '@angular/material/core';
import { MatDialog } from '@angular/material/dialog';
import { MatStepper } from '@angular/material/stepper';
import { Router } from '@angular/router';
import * as moment from 'moment';
import { ExamSessionModel } from 'src/app/models/exam-session.model';

export interface DialogData {
  addNewCourse: boolean;
}

@Component({
  selector: 'app-exam-session-modify-template',
  templateUrl: './exam-session-modify-template.component.html',
  styleUrls: ['./exam-session-modify-template.component.css'],
})
export class ExamSessionModifyTemplateComponent implements OnInit {

  @ViewChild('picker') picker: any;
  @ViewChild('picker2') picker2: any;

  @Input() showDialog: boolean = true;
  @Input() redirect: string;
  @Input() examSession: ExamSessionModel = {
    sessionId: 0,
    name: '',
    startDate: new Date(),
    endDate: new Date(),
    courseId: 0
  };
  @Output("onSave") onSavee: EventEmitter<ExamSessionModel> = new EventEmitter<ExamSessionModel>();

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  @ViewChild('stepper') stepper: MatStepper;

  
  constructor(
    private formBuilder: FormBuilder,
    public dialog: MatDialog,
    private router: Router
  ) {}

  ngOnInit() {
    this.firstFormGroup = this.formBuilder.group({
      examSessionName: ['', Validators.required],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required]
    });
    this.secondFormGroup = this.formBuilder.group({});
  }

  saveClick() {

    this.onSavee.emit(this.examSession);

    if(this.showDialog)
    {
      const dialogRef = this.dialog.open(SuccessDialogComponent, {
        width: '250px',
      });
  
      dialogRef.afterClosed().subscribe(result => {
        if(result)
          this.stepper.reset()
        else
          this.router.navigate([this.redirect]);
      });
    }
    else
    this.router.navigate([this.redirect]);
  }

  /*onSelectedUsersChange(users: UserModel[])
  {
    this.course.users = users;
  }*/

}

@Component({
  selector: 'success-dialog',
  templateUrl: 'success-dialog.component.html',
})
export class SuccessDialogComponent {
  constructor() {}
}
