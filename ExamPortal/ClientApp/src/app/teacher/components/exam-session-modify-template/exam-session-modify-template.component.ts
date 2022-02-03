import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatStepper } from '@angular/material/stepper';
import { Router } from '@angular/router';
import { ExamSessionModel } from 'src/app/models/exam-session.model';
import { CourseModel } from '../../models/course.model';
import { CourseService } from '../../services/course.service';

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
    startDate: null,
    endDate: null,
    courseId: 0
  };
  @Output("onSave") onSavee: EventEmitter<{examSession: ExamSessionModel; file: File}> = new EventEmitter<{examSession: ExamSessionModel; file: File}>();

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  @ViewChild('stepper') stepper: MatStepper;

  courses: CourseModel[];
  displayedColumns: string[] = ['index', 'name', 'users', 'creationDate'];

  fileName = '';
  file:File;
  
  constructor(
    private formBuilder: FormBuilder,
    public dialog: MatDialog,
    private router: Router,
    private courseService: CourseService
  ) {}

  ngOnInit() {
    this.firstFormGroup = this.formBuilder.group({
      examSessionName: ['', Validators.required],
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      file: ['', Validators.required]
    });

    this.secondFormGroup = this.formBuilder.group({});

    this.courseService.getListOfCourses().subscribe(result => {
      this.courses = result; 
    });
  }

  saveClick() {

    this.onSavee.emit({examSession: this.examSession, file: this.file});

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

  onSelectedCourseChange(course: CourseModel)
  {
    this.examSession.course = course;
    this.examSession.courseId = course.courseId;
  }

  onFileSelected(event)
  {
    if(event.target.files[0])
    {
      this.file = event.target.files[0];
      this.fileName = this.file.name;
    }
  }

}

@Component({
  selector: 'success-dialog',
  templateUrl: 'success-dialog.component.html',
})
export class SuccessDialogComponent {
  constructor() {}
}
