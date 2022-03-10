import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTooltipModule } from '@angular/material/tooltip';
import { RouterModule } from '@angular/router';
import { MatStepperModule } from '@angular/material/stepper';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTabsModule }  from '@angular/material/tabs';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { NgxMatDatetimePickerModule, NgxMatNativeDateModule } from '@angular-material-components/datetime-picker';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { ExamSessionTableTemplateComponent } from '../components/exam-sessions-table-template/exam-sessions-table-template.component';
import { MinuteSecondsPipe } from '../pipes/minute-second.pipe';
import { MatRadioModule } from '@angular/material/radio';
import { YesNoResultTemplateComponent } from '../components/yes-no-result-template/yes-no-result-template.component';
import { ClosedResultTemplateComponent } from '../components/closed-result-template/closed-result-template.component';
import { OpenResultTemplateComponent } from '../components/open-result-template/open-result-template.component';

@NgModule({
  declarations: [
    ExamSessionTableTemplateComponent,
    MinuteSecondsPipe,
    YesNoResultTemplateComponent,
    ClosedResultTemplateComponent,
    OpenResultTemplateComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    MatPaginatorModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    BrowserAnimationsModule,
    MatTooltipModule,
    MatStepperModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
    MatTabsModule,
    MatProgressBarModule,
    NgxMatDatetimePickerModule,
    NgxMatNativeDateModule,
    MatDatepickerModule,
    MatRadioModule
  ],
  exports: [
    RouterModule,
    MatPaginatorModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    BrowserAnimationsModule,
    MatTooltipModule,
    MatStepperModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
    MatTabsModule,
    NgxMatDatetimePickerModule,
    NgxMatNativeDateModule,
    MatDatepickerModule,
    ExamSessionTableTemplateComponent,
    MinuteSecondsPipe,
    MatRadioModule,
    YesNoResultTemplateComponent,
    ClosedResultTemplateComponent,
    OpenResultTemplateComponent
  ]
})
export class SharedModule { }
