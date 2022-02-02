import { Component } from '@angular/core';

@Component({
  selector: 'app-exam-session-creator',
  templateUrl: './exam-session-creator.component.html',
  styleUrls: []
})
export class ExamSessionCreatorComponent {
  redirect = '/teacher/exams-list';

  constructor() { }

  saveClick(event) {
    console.log(event);
  }
}
