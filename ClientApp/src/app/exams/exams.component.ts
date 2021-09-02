import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'exams',
  templateUrl: './exams.component.html',
  styleUrls: []
})
export class ExamsComponent implements OnInit {
  public exams: Exam[];

  constructor(private http: HttpClient, @Inject('BASE_URL')private baseUrl: string) { }

  ngOnInit() {
    this.http.get<Exam[]>(this.baseUrl + 'api/exams').subscribe(result => {
      this.exams = result;
    }, error => console.error(error));
  }
  
}

interface Exam {
  id: number;
  title: string;
  duration: number;
  questionsNumber: number;
}
