import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExamSessionComponent } from './components/exam-session/exam-session.component';
import { ExamSessionsListComponent } from './components/exam-sessions-list/exam-sessions-list.component';


@NgModule({
  declarations: [ExamSessionComponent, ExamSessionsListComponent],
  imports: [
    CommonModule
  ]
})
export class TeacherModule { } 