import { Component, Input, OnInit } from '@angular/core';
import { QuestionModel } from '../../models/question.model';

@Component({
  selector: 'yes-no-question-template',
  templateUrl: './yes-no-question-template.component.html',
  styleUrls: ['./yes-no-question-template.component.css']
})
export class YesNoQuestionTemplateComponent implements OnInit {

  @Input('question') question: QuestionModel;

  constructor() { }

  ngOnInit(): void {
  }

}
