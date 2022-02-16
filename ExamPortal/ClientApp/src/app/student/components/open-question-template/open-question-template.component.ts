import { Component, Input, OnInit } from '@angular/core';
import { QuestionModel } from '../../models/question.model';

@Component({
  selector: 'open-question-template',
  templateUrl: './open-question-template.component.html',
  styleUrls: ['./open-question-template.component.css']
})
export class OpenQuestionTemplateComponent implements OnInit {

  @Input('question') question: QuestionModel;

  constructor() { }

  ngOnInit(): void {
  }

}
