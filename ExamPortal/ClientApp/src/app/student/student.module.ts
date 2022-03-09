import { LOCALE_ID, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ExamsComponent } from './components/exams/exams.component';
import { ExamComponent } from './components/exam/exam.component';

import { ExamsService } from './services/exams.service';
import { SyncExamService } from './services/sync-exam.service';
import { SharedModule } from '../shared/shared.module';
import { StartExamDialogComponent } from './components/start-exam-dialog/start-exam-dialog.component';
import { TimerTemplateComponent } from './components/timer-template/timer-template.component';
import { ClosedQuestionTemplateComponent } from './components/closed-question-template/closed-question-template.component';
import { OpenQuestionTemplateComponent } from './components/open-question-template/open-question-template.component';
import { YesNoQuestionTemplateComponent } from './components/yes-no-question-template/yes-no-question-template.component';
import { ExamsResultsListComponent } from './components/exams-results-list/exams-results-list.component';


@NgModule({
  declarations: [
    ExamsComponent,
    ExamComponent,
    StartExamDialogComponent,
    TimerTemplateComponent,
    ClosedQuestionTemplateComponent,
    OpenQuestionTemplateComponent,
    YesNoQuestionTemplateComponent,
    ExamsResultsListComponent
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
