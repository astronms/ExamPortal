import { catchError, map } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

import { ExamModel } from '../models/exams.model';
import { GetQuestionReplyModel } from '../models/get-question-reply.model';

import { Inject, Injectable, LOCALE_ID } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { QuestionModel } from '../models/question.model';

@Injectable({
  providedIn: 'root'
})
export class ExamService {

  private questionReply: GetQuestionReplyModel;
  private question: QuestionModel;
  private timeLeft: number;
  private timeout: any;

  constructor(private http: HttpClient,  @Inject('BASE_URL')private baseUrl: string) { }

  getListOfExams() : Observable<ExamModel[]>{
    return this.http.get<ExamModel[]>(this.baseUrl + 'api/exam/getlist').pipe(catchError(this.handleError));
  }

  startExam(examId: number) : Observable<boolean>{
    return this.http.get<boolean>(this.baseUrl + 'api/exam/start',{ params: {
        id: examId.toString()
    }}).pipe(map(result => {
        localStorage.setItem("pendingExam", "true");
        return result;
    }), catchError(this.handleError));
  }

  isPendingExam() : boolean{
    return JSON.parse(localStorage.getItem("pendingExam"));
  }

  getQuestion() : Observable<QuestionModel>{
    return this.http.get<GetQuestionReplyModel>(this.baseUrl + 'api/exam/getquestion').pipe(map(result => {
      this.questionReply = result;
      this.timeLeft = result.leftTime;
      this.question = result.question;
      return result.question;
    }), catchError(this.handleError)); //ToDo: Catch 404 Response(Exam has been passed). 
  }

  setQuestionTimer() 
  {
    this.timeout = setTimeout(() => {
      console.log("Tiimer xd");
      this.sendAnswers();
    }, this.timeLeft * 1000); 

    this.http.get(this.baseUrl + "api/exam/starttime", {params: {
      id: this.question.id.toString()
    }}).subscribe(result => {}, error => {
      console.log(error);
    });
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