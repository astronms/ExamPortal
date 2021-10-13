import { ExamModel } from '../models/exams.model';

import { Component, Inject, LOCALE_ID, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';
import { Router } from '@angular/router';
import { ExamsService } from '../services/exams.service';
import { ExamFactoryService } from '../services/exam-factory.service';

@Component({
  selector: 'exams',
  templateUrl: './exams.component.html',
  styleUrls: []
})
export class ExamsComponent implements OnInit {
  public exams: ExamModel[];

  constructor(private examsService: ExamsService, private examFactoryService: ExamFactoryService, private router: Router, @Inject(LOCALE_ID)private locale: string) { }

  ngOnInit() {

    const datepipe: DatePipe = new DatePipe(this.locale);

    this.examsService.getListOfExams().subscribe(result => {
      result.forEach( exam => {
        exam.startDate =  datepipe.transform(exam.startDate, 'dd-MMM-yyyy HH:mm');
      });

      this.exams = result;
    });
  }

  startExam(examId: number) {
    this.examFactoryService.startExam(examId).subscribe(result => {
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
