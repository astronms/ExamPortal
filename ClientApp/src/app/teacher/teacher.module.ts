import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExamSessionComponent } from './components/exam-session/exam-session.component';
import { ExamSessionsListComponent } from './components/exam-sessions-list/exam-sessions-list.component';
import { ExamCreatorComponent } from './components/exam-creator/exam-creator.component';
import { CoursesListComponent } from './components/courses-list/courses-list.component';

import { ExamSessionService } from './services/exam-session.service';
import { MatTableModule } from '@angular/material/table';
import { ExamTableComponent } from '../components/exam-table/exam-table.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {RouterModule} from '@angular/router';
import { CourseService } from './services/course.service';
import { CourseCreatorComponent, SuccessDialogComponent } from './components/course-creator/course-creator.component';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatIconModule } from '@angular/material/icon';
import { MatStepperModule } from '@angular/material/stepper';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';

@NgModule({
  declarations: [
    ExamSessionComponent, 
    ExamSessionsListComponent,
    ExamCreatorComponent,
    CoursesListComponent,
    ExamTableComponent,
    CourseCreatorComponent,
    SuccessDialogComponent 
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    BrowserAnimationsModule,
    MatTooltipModule,
    RouterModule,
    MatStepperModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule
  ],
  providers: [
    ExamSessionService,
    CourseService
  ]
})
export class TeacherModule { } 