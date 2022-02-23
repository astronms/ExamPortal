import { ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { SyncExamService } from '../../services/sync-exam.service';
import { QuestionModel } from '../../models/question.model';


@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
  styleUrls: [],
})
export class ExamComponent implements OnInit, OnDestroy {

  public examFinished: boolean = false; 
  public actualQuestion: QuestionModel;
  public actualTime: number;

  constructor(
    private route: ActivatedRoute,
    private examService: SyncExamService,
    private cdRef: ChangeDetectorRef
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
      this.actualTime = question.time;
      this.cdRef.detectChanges();
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