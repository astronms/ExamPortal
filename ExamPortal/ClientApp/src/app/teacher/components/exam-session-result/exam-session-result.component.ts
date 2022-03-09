import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ExamSessionService } from '../../services/exam-session.service';

@Component({
  selector: 'app-exam-session-result',
  templateUrl: './exam-session-result.component.html',
  styleUrls: ['./exam-session-result.component.css']
})
export class ExamSessionResultComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private examSessionService: ExamSessionService
  ) { }

  async ngOnInit() {
    var examSessionId = this.route.snapshot.paramMap.get('id');
    const result = await this.examSessionService.getUsersWithCompletedExamData(examSessionId);
    console.log(result);
  }

}
