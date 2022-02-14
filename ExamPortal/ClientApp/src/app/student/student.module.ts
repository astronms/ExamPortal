import { LOCALE_ID, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ExamsComponent } from './components/exams/exams.component';
import { ExamComponent } from './components/exam/exam.component';

import { ExamsService } from './services/exams.service';
import { SyncExamService } from './services/sync-exam.service';
import { SharedModule } from '../shared/shared.module';
import { StartExamDialogComponent } from './components/start-exam-dialog/start-exam-dialog.component';


@NgModule({
  declarations: [
    ExamsComponent,
    ExamComponent,
    StartExamDialogComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'pl' },
    ExamsService,
    SyncExamService,
  ],
})
export class StudentModule { }
