import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatStepper } from '@angular/material/stepper';
import { Router } from '@angular/router';
import { UserModel } from 'src/app/models/user.model';
import { CourseModel } from '../../models/course.model';
import { SuccessDialogComponent } from '../success-dialog-template/success-dialog-template.component';

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
    creationDate: new Date(),
    sessions: [],
    users: [],
  }
  @Output() saveClicked: EventEmitter<CourseModel> = new EventEmitter<CourseModel>();

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

    this.saveClicked.emit(this.course);

    if(this.showDialog)
    {
      const dialogRef = this.dialog.open(SuccessDialogComponent, {
        width: '250px',
        data: { 
          componentName: "kurs"
        }
      });
  
      dialogRef.afterClosed().subscribe(result => {
        if(result)
        {
          this.course = {
            courseId: 0,
            name: "",
            creationDate: new Date(),
            sessions: [],
            users: [],
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

  onSelectedUsersChange(users: UserModel[])
  {
    this.course.users = users;
  }

}
