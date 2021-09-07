import { Component, Inject, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'exams',
  templateUrl: './exams.component.html',
  styleUrls: []
})
export class ExamsComponent implements OnInit {
  public exams: ExamModel[];

  constructor(private http: HttpClient, @Inject('BASE_URL')private baseUrl: string, private router: Router) { }

  ngOnInit() {
    const datepipe: DatePipe = new DatePipe('en-US');
    
    this.http.get<ExamModel[]>(this.baseUrl + 'api/exam/getlist').subscribe(result => {
      this.exams = result;
      this.exams.forEach( exam => {
        exam.startDate =  datepipe.transform(exam.startDate, 'dd-MMM-yyyy HH:mm');
      });
    }, error => console.error(error));

  }

  isExamAvailable(examId: number): boolean {
    return true;
  }

  startExam(examId: number) {
    this.http.get<boolean>(this.baseUrl + 'api/exam/start',
    {params: {
      id: examId.toString()
    }}).subscribe(result => {
      if(result)
      {
        localStorage.setItem("pendingExam", "true");
        this.router.navigate(["/exam"]); 
      }
      else
      {
        //TODO: implement error page and redirect
        console.log("Cannot access the exam.");
      }
    }, error => console.error(error));
  }
  
}

interface ExamModel {
  id: number;
  title: string;
  duration: number;
  questionsNumber: number;
  startDate: string;
}
