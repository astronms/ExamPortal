import { Component, Input, OnInit } from '@angular/core';
import { QuestionModel } from '../../models/question.model';

@Component({
  selector: 'closed-question-template',
  templateUrl: './closed-question-template.component.html',
  styleUrls: ['./closed-question-template.component.css']
})
export class ClosedQuestionTemplateComponent implements OnInit {

  @Input('question') question: QuestionModel;

  constructor() { }

  ngOnInit(): void {
  }

}
