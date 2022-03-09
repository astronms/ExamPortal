import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SyncExamService } from '../../services/sync-exam.service';

@Component({
  selector: 'app-exam-result',
  templateUrl: './exam-result.component.html',
  styleUrls: ['./exam-result.component.css']
})
export class ExamResultComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private examService: SyncExamService,
  ) { }

  ngOnInit(): void {
    var examResultId = this.route.snapshot.paramMap.get('id');
    this.examService.getExamResult(examResultId).subscribe(result => {
      console.log(result);
    })
  }

}
