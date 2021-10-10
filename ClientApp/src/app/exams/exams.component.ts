import { ExamModel } from '../models/exams.model';

import { Component, Inject, LOCALE_ID, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import { ExamService } from '../services/exam.service';

@Component({
  selector: 'exams',
  templateUrl: './exams.component.html',
  styleUrls: []
})
export class ExamsComponent implements OnInit {
  public exams: ExamModel[];

  constructor(private examService: ExamService, private router: Router, @Inject(LOCALE_ID)private locale: string) { }

  ngOnInit() {
    const datepipe: DatePipe = new DatePipe(this.locale);

    this.examService.getListOfExams().subscribe(result => {
      result.forEach( exam => {
        exam.startDate =  datepipe.transform(exam.startDate, 'dd-MMM-yyyy HH:mm');
      });

      this.exams = result;
    });
  }

  startExam(examId: number) {
    this.examService.startExam(examId).subscribe(result => {
      if(result)
        this.router.navigate(["/exam"]); 
      else
      {
        //TODO: implement error page and redirect
        console.log("Cannot access the exam.");
      }
    });
  }
  
}
