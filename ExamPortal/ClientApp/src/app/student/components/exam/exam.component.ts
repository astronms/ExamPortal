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

  public examFinished: boolean = false; 
  public actualQuestion: QuestionModel;

  constructor(
    private route: ActivatedRoute,
    private examService: SyncExamService
  ) { }

  ngOnInit() {
    var examId = this.route.snapshot.paramMap.get('id');
    this.examService.startExam(examId);
    this.setListeners();
  }

  ngOnDestroy(): void {
    this.examService.closeConnection();
  }

  setListeners()
  {
    this.examService.questions.subscribe(question => {
      this.actualQuestion = question;
    });

    this.examService.examFinished.subscribe(value => {
      this.examFinished = value;
    });
  }

  onAnswer(event) : void
  {
    this.examService.sendAnswers(event);
  }
  
}