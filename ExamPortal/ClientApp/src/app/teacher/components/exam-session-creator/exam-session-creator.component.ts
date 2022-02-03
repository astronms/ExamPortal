import { Component } from '@angular/core';
import { ExamSessionService } from '../../services/exam-session.service';

@Component({
  selector: 'app-exam-session-creator',
  templateUrl: './exam-session-creator.component.html',
  styleUrls: []
})
export class ExamSessionCreatorComponent {
  redirect = '/teacher/exams-list';

  constructor(
    private examSessionService: ExamSessionService
  ) { }

  saveClick(event) {
    this.examSessionService.addExamSession(event.examSession, event.file).subscribe();
  }
}
