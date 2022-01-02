import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExamSessionComponent } from './components/exam-session/exam-session.component';
import { ExamSessionsListComponent } from './components/exam-sessions-list/exam-sessions-list.component';
import { ExamCreatorComponent } from './components/exam-creator/exam-creator.component';
import { CoursesListComponent } from './components/courses-list/courses-list.component';
import { ExamTableComponent } from '../components/exam-table/exam-table.component';
import { CourseCreatorComponent, SuccessDialogComponent } from './components/course-creator/course-creator.component';

import { ExamSessionService } from './services/exam-session.service';
import { CourseService } from './services/course.service';
import { SharedModule } from '../shared/shared.module';

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
    SharedModule
  ],
  providers: [
    ExamSessionService,
    CourseService
  ]
})
export class TeacherModule { } 