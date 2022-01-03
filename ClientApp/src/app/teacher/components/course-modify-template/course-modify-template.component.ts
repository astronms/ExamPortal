import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatStepper } from '@angular/material/stepper';
import { Router } from '@angular/router';
import { CourseModel } from '../../models/course.model';

export interface DialogData {
  addNewCourse: boolean;
}

@Component({
  selector: 'app-course-modify-template',
  templateUrl: './course-modify-template.component.html',
  styleUrls: ['./course-modify-template.component.css']
})
export class CourseModifyTemplateComponent implements OnInit {

  @Input() showDialog: boolean = true;
  @Input() redirect: string;
  @Input() course: CourseModel = {
    courseId: 0,
    name: "",
    creationDate: "",
    sessions: [],
    users: [],
  }
  @Output("onSave") onSavee: EventEmitter<CourseModel> = new EventEmitter<CourseModel>();

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
      courseName: ['', Validators.required],
    });
    this.secondFormGroup = this.formBuilder.group({});
  }

  saveClick() {

    this.onSavee.emit(this.course);

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

}

@Component({
  selector: 'success-dialog',
  templateUrl: 'success-dialog.component.html',
})
export class SuccessDialogComponent {
  constructor() {}
}
