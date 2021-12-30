import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { MatStepper } from '@angular/material/stepper';
import { Router } from '@angular/router';
import { CourseService } from '../../services/course.service';

export interface DialogData {
  addNewCourse: boolean;
}

@Component({
  selector: 'app-course-creator',
  templateUrl: './course-creator.component.html',
  styleUrls: ['./course-creator.component.css']
})
export class CourseCreatorComponent implements OnInit {

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  @ViewChild('stepper') stepper: MatStepper;
  courseNameValue: string;

  
  constructor(
    private formBuilder: FormBuilder,
    private courseService: CourseService, 
    public dialog: MatDialog,
    private router: Router
  ) {}

  ngOnInit() {
    this.firstFormGroup = this.formBuilder.group({
      courseName: ['', Validators.required],
    });
    this.secondFormGroup = this.formBuilder.group({});
  }

  addCourseClick() {
    this.courseService.addCourse(this.courseNameValue).subscribe(result =>
      {
        const dialogRef = this.dialog.open(SuccessDialogComponent, {
          width: '250px',
        });
    
        dialogRef.afterClosed().subscribe(result => {
          if(result)
            this.stepper.reset()
          else
            this.router.navigate(['/teacher/courses-list']);
        });
      }
    )
  }

}

@Component({
  selector: 'success-dialog',
  templateUrl: 'success-dialog.component.html',
})
export class SuccessDialogComponent {
  constructor() {}
}
