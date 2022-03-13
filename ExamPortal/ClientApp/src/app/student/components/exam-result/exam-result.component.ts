import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ExamResultModel } from 'src/app/models/exam-result-model';
import { SyncExamService } from '../../services/sync-exam.service';

@Component({
  selector: 'app-exam-result',
  templateUrl: './exam-result.component.html',
  styleUrls: ['./exam-result.component.css']
})
export class ExamResultComponent implements OnInit {

  examResult: ExamResultModel

  constructor(
    private route: ActivatedRoute,
    private examService: SyncExamService,
  ) { }

  ngOnInit(): void {
    var examResultId = this.route.snapshot.paramMap.get('id');
    this.examService.getExamResult(examResultId).subscribe(result => {
      this.examResult = result;
    })
  }

}
