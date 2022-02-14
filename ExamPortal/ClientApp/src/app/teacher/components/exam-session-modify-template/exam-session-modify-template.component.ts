import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatStepper } from '@angular/material/stepper';
import { Router } from '@angular/router';
import { ExamSessionModel } from 'src/app/models/exam-session.model';
import { CourseModel } from '../../models/course.model';
import { CourseService } from '../../services/course.service';
import { SuccessDialogComponent } from '../success-dialog-template/success-dialog-template.component';

@Component({
  selector: 'app-exam-session-modify-template',
  templateUrl: './exam-session-modify-template.component.html',
  styleUrls: ['./exam-session-modify-template.component.css'],
})
export class ExamSessionModifyTemplateComponent implements OnInit {

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;

  courses: CourseModel[];
  displayedColumns: string[] = ['index', 'name', 'users', 'creationDate'];

  fileName = '';
  file:File = null;

  @ViewChild('picker') picker: any;
  @ViewChild('picker2') picker2: any;
  @ViewChild('stepper') stepper: MatStepper;

  @Input("showDialog") showDialog: boolean = true;
  @Input("redirect") redirect: string;
  @Input("examSession") examSession: ExamSessionModel = {
    sessionId: 0,
    name: '',
    startDate: null,
    endDate: null,
    courseId: null
  };
  @Output("onSave") onSavee: EventEmitter<{examSession: ExamSessionModel; file: File}> = new EventEmitter<{examSession: ExamSessionModel; file: File}>();
  
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

    this.secondFormGroup = this.formBuilder.group({
      courseSelect: [this.examSession.courseId ? this.examSession.courseId : '', Validators.required]
    });

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
        data: { 
          componentName: "egzamin"
        }
      });
  
      dialogRef.afterClosed().subscribe(result => {
        if(result)
        {
          this.fileName = '';
          this.examSession = {
            sessionId: 0,
            name: '',
            startDate: null,
            endDate: null,
            courseId: null
          };
          this.stepper.reset();
        }
        else
          this.router.navigate([this.redirect]);
      });
    }
    else
    this.router.navigate([this.redirect]);
  }

  onSelectedCourseChange(course: CourseModel)
  {
    this.secondFormGroup.patchValue({courseSelect: course ? course.name : ""})
    this.examSession.course = course;
    this.examSession.courseId = course ? course.courseId : null;
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
