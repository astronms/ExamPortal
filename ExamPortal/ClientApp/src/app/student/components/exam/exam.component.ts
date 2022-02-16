import { Component, Inject, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { SyncExamService } from '../../services/sync-exam.service';
import { QuestionModel } from '../../models/question.model';


@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
  styleUrls: [],
})
export class ExamComponent implements OnDestroy {

  //private interval: any = null;
  public actualQuestion: QuestionModel;

  constructor(
    private route: ActivatedRoute,
    private examService: SyncExamService
  ) { }

  ngOnInit() {
    var examId = this.route.snapshot.paramMap.get('id');
    this.examService.startExam(examId);
    this.setQuestionListener();
  }

  ngOnDestroy(): void {
    this.examService.closeConnection();
  }

  setQuestionListener()
  {
    this.examService.questions.subscribe(question => {
      this.actualQuestion = question;
    });
  }

  /*ngOnDestroy() {
    clearInterval(this.interval);
  }
  

  private setViewTimer() : void
  {
    this.interval = setInterval(() => {
      this.timeLeft--;
    }, 1000)
  }*/
  
}