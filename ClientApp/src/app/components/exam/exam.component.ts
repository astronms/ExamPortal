import { QuestionModel } from '../../models/question.model';
import { GetQuestionReplyModel } from '../../models/get-question-reply.model';
import { AuthService } from '../../services/auth.service';
import { ExamFactoryService } from '../../services/exam-factory.service';
import { ExamStatusEnum } from '../../enums/exam-status.enum';

import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ExamInterface } from '../../interfaces/exam.interface';


@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
})
export class ExamComponent {

  private examService : ExamInterface;

  public question: QuestionModel;
  public questionReply: GetQuestionReplyModel;
  public timeLeft: number;

  public examFinished: boolean = false;

  private interval: any = null;

  constructor(private router: Router, private authService: AuthService, private examFactoryService: ExamFactoryService) { }

  ngOnInit() {

    try {
      this.examService = this.examFactoryService.getInstance();

      this.examService.examStatusObservable.subscribe(result => {
        if(result == ExamStatusEnum.EndQuestionTime)
          this.nextQuestion();
        else if(result == ExamStatusEnum.Finished)
          this.examFinished = true;
      });

      if(!this.examService.isPendingExam())
        this.router.navigate(["/exams"]);
      else
        this.nextQuestion();
    }
    catch(e)
    {
      console.log("Error in exam component!"); //Redirect to error page.
    }
  }

  ngOnDestroy() {
    this.examService.removeTimer();
    clearInterval(this.interval);
  }

  nextQuestion() : void {

    if(this.interval != null)
      clearInterval(this.interval);

    this.examService.getQuestion().subscribe(result => {
      this.question = result; //TODO: handle error
      this.timeLeft = this.examService.getLeftTime();
      this.setViewTimer();
    }); 
      
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
    }, 1000)
  }
  
}