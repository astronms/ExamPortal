import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';

import { ExamSessionService } from './services/exam-session.service';
import { CourseService } from './services/course.service';

import { ExamSessionComponent } from './components/exam-session/exam-session.component';
import { ExamSessionsListComponent } from './components/exam-sessions-list/exam-sessions-list.component';
import { ExamCreatorComponent } from './components/exam-creator/exam-creator.component';
import { CoursesListComponent } from './components/courses-list/courses-list.component';
import { ExamTableComponent } from '../components/exam-table/exam-table.component';
import { CourseCreatorComponent } from './components/course-creator/course-creator.component';
import { CourseComponent } from './components/course/course.component';
import { CourseEditComponent } from './components/course-edit/course-edit.component';
import { CourseModifyTemplateComponent, SuccessDialogComponent } from './components/course-modify-template/course-modify-template.component';
import { StudentsListComponent } from './components/students-list/students-list.component';


@NgModule({
  declarations: [
    ExamSessionComponent, 
    ExamSessionsListComponent,
    ExamCreatorComponent,
    CoursesListComponent,
    ExamTableComponent,
    CourseCreatorComponent,
    SuccessDialogComponent,
    CourseComponent,
    CourseEditComponent,
    CourseModifyTemplateComponent,
    StudentsListComponent 
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