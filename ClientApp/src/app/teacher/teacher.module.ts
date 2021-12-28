import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExamSessionComponent } from './components/exam-session/exam-session.component';
import { ExamSessionsListComponent } from './components/exam-sessions-list/exam-sessions-list.component';

import { ExamSessionService } from './services/exam-session.service';
import { MatButtonModule, MatIconModule, MatTableModule } from '@angular/material';


@NgModule({
  declarations: [
    ExamSessionComponent, 
    ExamSessionsListComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule
  ],
  providers: [
    ExamSessionService
  ]
})
export class TeacherModule { } 