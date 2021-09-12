import { HttpClient } from '@angular/common/http';
import { Component, Inject, Query } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-exam',
  templateUrl: './exam.component.html',
})
export class ExamComponent {

  public question: QuestionModel;
  public questionReply: GetQuestionReplyModel;
  public timeLeft: number;

  public examFinished: boolean = false;

  private interval: any;

  constructor(private router: Router, @Inject('BASE_URL')private baseUrl: string, private authService: AuthService, private http: HttpClient ) { }

  ngOnInit() {
    var pendingExam = localStorage.getItem("pendingExam");

    if(pendingExam != "true")
      this.router.navigate(["/exams"]);
    
    if(!this.examFinished)
      this.getQuestion();
    else
      localStorage.removeItem("pendingExam");
      
  }

  ngOnDestroy() {
    clearInterval(this.interval);
  }

  sendAnswers()
  {
    console.log("answers sent.");
    clearInterval(this.interval);
    this.http.get(this.baseUrl + "api/exam/saveanswers", {params: {
      id: this.question.id.toString()
    }}).subscribe(result => {
      this.finishExamIfNeeded();
      this.ngOnInit();
    }, error => {
      console.log(error);
    });
    
  }

  private getQuestion() {
    this.http.get<GetQuestionReplyModel>(this.baseUrl + 'api/exam/getquestion').subscribe(result => {

      this.questionReply = result;
      this.question = result.question;
      this.http.get(this.baseUrl + "api/exam/starttime", {params: {
        id: this.question.id.toString()
      }}).subscribe(result => {
        this.timeLeft = this.questionReply.leftTime;

        this.interval = setInterval(() => {
          if(this.timeLeft > 0) {
            this.timeLeft--;
          } else {
            this.sendAnswers();
          }
        },1000)
      }, error => {
        console.error(error);
      })
      
    }, error => console.error(error)); //ToDo: move logic to exam.service and catch 404 Response(Exam has been passed). 
  }

  private finishExamIfNeeded() {
    if(this.questionReply.currentQuestionNumber == this.questionReply.examQuestionQuantity)
      this.examFinished = true;
  }
}

interface GetQuestionReplyModel {
  examQuestionQuantity: number;
  currentQuestionNumber: number;
  leftTime: number;
  question: QuestionModel;
}
interface QuestionModel {
  id: number;
  content: string;
  time: number;
  answers: AnswerModel[];
}

interface AnswerModel {
  id: number;
  content: string;
  selectedOption: boolean;
}