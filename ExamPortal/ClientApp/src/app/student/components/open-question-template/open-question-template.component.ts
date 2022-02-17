import { AfterContentInit, Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AnswerModel, AnswerValueModel } from '../../models/answer.model';

import { QuestionModel } from '../../models/question.model';

@Component({
  selector: 'open-question-template',
  templateUrl: './open-question-template.component.html',
  styleUrls: ['./open-question-template.component.css']
})
export class OpenQuestionTemplateComponent implements AfterContentInit, OnInit {

  public image: string = null;

  formGroup = new FormGroup({});

  @Input('question') question: QuestionModel;
  @Output('onAnswer') onAnswer: EventEmitter<AnswerModel> = new EventEmitter<AnswerModel>();

  constructor() {}

  ngOnInit(): void {
    this.question.values.forEach(value => {
      if(!value.regex)
        this.formGroup.addControl('formId_' + value.sortId, new FormControl(''));
      else
        this.formGroup.addControl('formId_' + value.sortId, new FormControl('', Validators.pattern(value.regex)));
    });
  }

  ngAfterContentInit(): void 
  {
    if(this.question.image) {
      if(this.question.imageType.toLowerCase() == 'png')
        this.image = "data:image/PNG;base64," + this.question.image;
      else
        this.image = "data:image/JPEG;base64," + this.question.image;
    }
  }

  onSubmit()
  {
    if (this.formGroup.valid) {
      var answer: AnswerModel = {
        taskId: this.question.taskId,
        values: []
      };
      this.question.values.forEach(value => {
        var answerValue: AnswerValueModel = {
          sortId: value.sortId,
          answer: this.formGroup.get('formId_' + value.sortId).value
        };
        answer.values.push(answerValue);
      });

      this.onAnswer.emit(answer);
    }
  }

  getErrorMessage(field: string)
  {
    var form = this.formGroup.get(field);
    if(!form)
      return null;
    
    return 'Wartość w nieprawidłowym formacie.'
  }

}
