import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExamSessionComponent } from './components/exam-session/exam-session.component';
import { ExamSessionsListComponent } from './components/exam-sessions-list/exam-sessions-list.component';
import { ExamCreatorComponent } from './components/exam-creator/exam-creator.component';
import { CoursesListComponent } from './components/courses-list/courses-list.component';

import { ExamSessionService } from './services/exam-session.service';
import { MatAutocompleteModule, MatButtonModule, MatIconModule, MatInputModule, MatNativeDateModule, MatStepperModule, MatTableModule, MatTooltipModule } from '@angular/material';
import { ExamTableComponent } from '../components/exam-table/exam-table.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {RouterModule} from '@angular/router';
import { CourseService } from './services/course.service';
import { CourseCreatorComponent } from './components/course-creator/course-creator.component';

@NgModule({
  declarations: [
    ExamSessionComponent, 
    ExamSessionsListComponent,
    ExamCreatorComponent,
    CoursesListComponent,
    ExamTableComponent,
    CourseCreatorComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    BrowserAnimationsModule,
    MatTooltipModule,
    RouterModule
  ],
  providers: [
    ExamSessionService,
    CourseService
  ]
})
export class TeacherModule { } 