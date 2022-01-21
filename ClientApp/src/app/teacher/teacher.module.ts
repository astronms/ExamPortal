import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';

import { ExamSessionService } from './services/exam-session.service';
import { CourseService } from './services/course.service';

import { ExamSessionComponent } from './components/exam-session/exam-session.component';
import { ExamSessionsListComponent } from './components/exam-sessions-list/exam-sessions-list.component';
import { ExamSessionCreatorComponent } from './components/exam-session-creator/exam-session-creator.component';
import { CoursesListComponent } from './components/courses-list/courses-list.component';
import { ExamTableComponent } from '../components/exam-sessions-table-template/exam-sessions-table-template.component';
import { CourseCreatorComponent } from './components/course-creator/course-creator.component';
import { CourseComponent } from './components/course/course.component';
import { CourseEditComponent } from './components/course-edit/course-edit.component';
import { CourseModifyTemplateComponent, SuccessDialogComponent } from './components/course-modify-template/course-modify-template.component';
import { StudentsListTemplateComponent } from './components/students-list-template/students-list-template.component';
import { CoursesListTemplateComponent } from './components/courses-list-template/courses-list-template.component';
import { CourseDeleteComponent } from './components/course-delete/course-delete.component';


@NgModule({
  declarations: [
    ExamSessionComponent, 
    ExamSessionsListComponent,
    ExamSessionCreatorComponent,
    CoursesListComponent,
    ExamTableComponent,
    CourseCreatorComponent,
    SuccessDialogComponent,
    CourseComponent,
    CourseEditComponent,
    CourseModifyTemplateComponent,
    StudentsListTemplateComponent,
    CoursesListTemplateComponent,
    CourseDeleteComponent
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