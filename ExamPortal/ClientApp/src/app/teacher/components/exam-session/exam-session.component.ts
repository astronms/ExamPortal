import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ExamSessionModel } from 'src/app/models/exam-session.model';
import { ExamSessionService } from '../../services/exam-session.service';

@Component({
  selector: 'app-exam-session',
  templateUrl: './exam-session.component.html',
  styleUrls: ['./exam-session.component.css']
})
export class ExamSessionComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private examSessionService: ExamSessionService
  ) { }

  examSession: ExamSessionModel;

  ngOnInit() {
    var guid = this.route.snapshot.paramMap.get('id');
    this.examSessionService.getExamSession(guid).subscribe(result => {
      this.examSession = result
    });
  }

}
