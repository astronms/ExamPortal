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
  public timeLeft: number;

  constructor(private router: Router, @Inject('BASE_URL')private baseUrl: string, private authService: AuthService, private http: HttpClient ) { }

  ngOnInit() {
    var pendingExam = localStorage.getItem("pendingExam");

    if(pendingExam != "true")
      this.router.navigate(["/exams"]);
    
      this.http.get<QuestionModel>(this.baseUrl + 'api/exam/getquestion').subscribe(result => {
        this.question = result;
        this.timeLeft = result.time;

        let interval;
        interval = setInterval(() => {
          if(this.timeLeft > 0) {
            this.timeLeft--;
          } else {
            this.ngOnInit();
          }
        },1000)

      }, error => console.error(error)); //ToDo: move logic to exam.service and catch 404 Response(Exam has been passed). 
  }
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