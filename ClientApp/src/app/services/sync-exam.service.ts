import { catchError, map } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

import { GetQuestionReplyModel } from '../models/get-question-reply.model';
import { QuestionModel } from '../models/question.model';
import { ExamInterface } from './Interfaces/exam.interface';

import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SyncExamService implements ExamInterface{

  private questionReply: GetQuestionReplyModel;
  private question: QuestionModel;
  private timeLeft: number;
  private timeout: any;

  constructor(private http: HttpClient,  @Inject('BASE_URL')private baseUrl: string) { }

  isPendingExam() : boolean{
    return JSON.parse(localStorage.getItem("pendingExam"));
  }

  getQuestion() : Observable<QuestionModel>{
    return this.http.get<GetQuestionReplyModel>(this.baseUrl + 'api/exam/getquestion').pipe(map(result => {
      this.questionReply = result;
      this.timeLeft = result.leftTime;
      this.question = result.question;
      this.setQuestionTimer();
      return result.question;
    }), catchError(this.handleError)); //ToDo: Catch 404 Response(Exam has been passed). 
  }

  sendAnswers() : void
  {
    clearTimeout(this.timeout);
    this.finishExamIfNeeded();
    this.http.get(this.baseUrl + "api/exam/saveanswers", {params: {
      id: this.question.id.toString()
    }}).subscribe(result => { }, error => {
      console.log(error);
    });
  }

  getLeftTime() : number {
    return this.timeLeft;
  }

  removeTimer() : void {
    clearTimeout(this.timeout);
  }

  private setQuestionTimer() 
  {
    this.timeout = setTimeout(() => {
      this.sendAnswers();
    }, this.timeLeft * 1000); 

    this.http.get(this.baseUrl + "api/exam/starttime", {params: {
      id: this.question.id.toString()
    }}).subscribe(result => {}, error => {
      console.log(error);
    });
  }

  private finishExamIfNeeded() : void {
    if(this.questionReply.currentQuestionNumber == this.questionReply.examQuestionQuantity) {
      this.removeTimer();
      localStorage.removeItem("pendingExam");
    }
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      console.error('An error occurred:', error.error);
    } else {
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    return throwError(
      'Something bad happened; please try again later.');
  }

}