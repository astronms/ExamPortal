import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';

import { ExamSessionService } from './services/exam-session.service';
import { CourseService } from './services/course.service';

import { ExamSessionComponent } from './components/exam-session/exam-session.component';
import { ExamSessionsListComponent } from './components/exam-sessions-list/exam-sessions-list.component';
import { ExamSessionCreatorComponent } from './components/exam-session-creator/exam-session-creator.component';
import { CoursesListComponent } from './components/courses-list/courses-list.component';
import { CourseCreatorComponent } from './components/course-creator/course-creator.component';
import { CourseComponent } from './components/course/course.component';
import { CourseEditComponent } from './components/course-edit/course-edit.component';
import { CourseModifyTemplateComponent } from './components/course-modify-template/course-modify-template.component';
import { StudentsListTemplateComponent } from './components/students-list-template/students-list-template.component';
import { CoursesListTemplateComponent } from './components/courses-list-template/courses-list-template.component';
import { CourseDeleteComponent } from './components/course-delete/course-delete.component';
import { ExamSessionModifyTemplateComponent } from './components/exam-session-modify-template/exam-session-modify-template.component'; 
import { SuccessDialogComponent } from './components/success-dialog-template/success-dialog-template.component';
import { ExamSessionDeleteComponent } from './components/exam-session-delete/exam-session-delete.component';
import { ExamSessionEditComponent } from './components/exam-session-edit/exam-session-edit.component';
import { ExamSessionResultsListComponent } from './components/exam-session-results-list/exam-session-results-list.component';
import { UploadResultDialogComponent } from './components/upload-result-dialog-template/upload-result-dialog-template.component';
import { ExamSessionResultComponent } from './components/exam-session-result/exam-session-result.component';

@NgModule({
  declarations: [
    ExamSessionComponent, 
    ExamSessionsListComponent,
    ExamSessionModifyTemplateComponent,
    ExamSessionCreatorComponent,
    ExamSessionDeleteComponent,
    CoursesListComponent,
    CourseCreatorComponent,
    CourseComponent,
    CourseEditComponent,
    CourseModifyTemplateComponent,
    StudentsListTemplateComponent,
    CoursesListTemplateComponent,
    CourseDeleteComponent,
    SuccessDialogComponent,
    ExamSessionEditComponent,
    ExamSessionResultsListComponent,
    UploadResultDialogComponent,
    ExamSessionResultComponent
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