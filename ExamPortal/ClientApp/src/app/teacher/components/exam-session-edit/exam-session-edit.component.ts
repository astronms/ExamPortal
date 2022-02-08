import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ExamSessionModel } from 'src/app/models/exam-session.model';
import { ExamSessionService } from '../../services/exam-session.service';

@Component({
  selector: 'app-exam-session-edit',
  templateUrl: './exam-session-edit.component.html',
  styleUrls: ['./exam-session-edit.component.css']
})
export class ExamSessionEditComponent implements OnInit {

  examSession: ExamSessionModel;
  redirect = '/teacher/exams-list';

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private examSessionService: ExamSessionService
  ) { }

  ngOnInit(): void {
    var examId = this.route.snapshot.paramMap.get('id');
    this.examSessionService.getExamSession(examId)
      .subscribe(result => {
        if(!result)
          this.router.navigate(["/404"]);
        this.examSession = result;
      });
  }

  saveClick(event) {
    this.examSessionService.modifyExamSession(event.examSession, event.file).subscribe();
  }

}
