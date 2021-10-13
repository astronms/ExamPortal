import { QuestionModel } from '../models/question.model';
import { GetQuestionReplyModel } from '../models/get-question-reply.model';
import { AuthService } from '../services/auth.service';
import { ExamService } from '../services/exam.service';

import { Component } from '@angular/core';
import { Router } from '@angular/router';


@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
})
export class ExamComponent {

  public question: QuestionModel;
  public questionReply: GetQuestionReplyModel;
  public timeLeft: number;

  public examFinished: boolean = false;

  private interval: any = null;

  constructor(private router: Router, private authService: AuthService, private examService: ExamService) { }

  ngOnInit() {
    if(!this.examService.isPendingExam())
      this.router.navigate(["/exams"]);
    else
      this.nextQuestion();
  }

  ngOnDestroy() {
    this.examService.removeTimer();
    clearInterval(this.interval);
  }

  nextQuestion() : void {

    if(this.interval != null)
      clearInterval(this.interval);

    if(this.examService.isPendingExam()) {
      this.examService.getQuestion().subscribe(result => {
        this.question = result; //TODO: handle error
        this.timeLeft = this.examService.getLeftTime();
        this.setViewTimer();
      }); 
    }
    else
      this.examFinished = true;
  }

  sendAnswers() : void
  {
    this.examService.sendAnswers() //TODO: send real answers and handle errors 
    this.nextQuestion();
  }

  private setViewTimer() : void
  {
    this.interval = setInterval(() => {
      this.timeLeft--;
      if(this.timeLeft <= 0)
        this.nextQuestion();
    }, 1000)
  }
  
}