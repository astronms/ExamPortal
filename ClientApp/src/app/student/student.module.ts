import { LOCALE_ID, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ExamsComponent } from './components/exams/exams.component';
import { ExamComponent } from './components/exam/exam.component';

import { ExamsService } from './services/exams.service';
import { ExamFactoryService } from './services/exam-factory.service';
import { SyncExamService } from './services/sync-exam.service';


@NgModule({
  declarations: [
    ExamsComponent,
    ExamComponent
  ],
  imports: [
    CommonModule
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'pl' },
    ExamsService,
    ExamFactoryService,
    SyncExamService,
  ],
})
export class StudentModule { }
