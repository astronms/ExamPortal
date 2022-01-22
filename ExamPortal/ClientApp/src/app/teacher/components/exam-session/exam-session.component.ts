import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-exam-session',
  templateUrl: './exam-session.component.html',
  styleUrls: ['./exam-session.component.css']
})
export class ExamSessionComponent implements OnInit {

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    console.log(this.route.snapshot.paramMap.get('id'));
  }

}
