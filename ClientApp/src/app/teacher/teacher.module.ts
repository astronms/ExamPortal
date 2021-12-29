import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExamSessionComponent } from './components/exam-session/exam-session.component';
import { ExamSessionsListComponent } from './components/exam-sessions-list/exam-sessions-list.component';
import { ExamCreatorComponent } from './components/exam-creator/exam-creator.component';
import { CoursesListComponent } from './components/courses-list/courses-list.component';


@NgModule({
  declarations: [
    ExamSessionComponent, 
    ExamSessionsListComponent,
    ExamCreatorComponent,
    CoursesListComponent
  ],
  imports: [
    CommonModule
  ]
})
export class TeacherModule { } 