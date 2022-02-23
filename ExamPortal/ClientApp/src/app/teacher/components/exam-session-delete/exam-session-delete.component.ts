import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ExamSessionModel } from 'src/app/models/exam-session.model';
import { ExamSessionService } from '../../services/exam-session.service';

@Component({
  selector: 'app-exam-session-delete',
  templateUrl: './exam-session-delete.component.html',
  styleUrls: ['./exam-session-delete.component.css']
})
export class ExamSessionDeleteComponent implements OnInit {

  examSession: ExamSessionModel;

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

  deleteClick()
  {
    this.examSessionService.deleteExamSession(this.examSession).subscribe(() => 
      this.router.navigate(["/teacher/exams-list"])
    );
  }

}
