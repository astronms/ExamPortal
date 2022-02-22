import { AfterContentInit, Component, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators, NgForm } from '@angular/forms';
import { AnswerModel, AnswerValueModel } from '../../models/answer.model';

import { QuestionModel } from '../../models/question.model';

@Component({
  selector: 'open-question-template',
  templateUrl: './open-question-template.component.html',
  styleUrls: ['./open-question-template.component.css']
})
export class OpenQuestionTemplateComponent implements AfterContentInit {

  public image: string = null;
  public _question: QuestionModel
  public formGroup = new FormGroup({});

  @Input('question') set question(questionData: QuestionModel) {
    if(this._question)
    {
      if(questionData.taskId != this._question.taskId)
        this.refreshContent(questionData);
    }
    else
      this.refreshContent(questionData);
  };
  @Output('onAnswer') onAnswer: EventEmitter<AnswerModel> = new EventEmitter<AnswerModel>();
  @ViewChild('questionForm') form : NgForm; 

  constructor() {}

  ngAfterContentInit(): void 
  {
    this.loadImage();
  }

  onSubmit()
  {
    if (this.formGroup.valid) {
      var answer: AnswerModel = {
        taskId: this._question.taskId,
        values: []
      };
      this._question.values.forEach(value => {
        var answerValue: AnswerValueModel = {
          sortId: value.sortId,
          answer: this.formGroup.get('formId_' + value.sortId).value
        };
        answer.values.push(answerValue);
      });

      this.onAnswer.emit(answer);
    }
  }

  private refreshContent(question: QuestionModel) : void
  {
    this._question = question;
    question.values.forEach(value => {
      if(!value.regex)
        this.formGroup.addControl('formId_' + value.sortId, new FormControl(''));
      else
        this.formGroup.addControl('formId_' + value.sortId, new FormControl('', Validators.pattern(value.regex)));
    });
    this.loadImage();
    if(this.form)
      this.form.reset();
  }

  private loadImage() : void 
  {
    if(this._question.image) {
      if(this._question.imageType.toLowerCase() == 'png')
        this.image = "data:image/PNG;base64," + this._question.image;
      else
        this.image = "data:image/JPEG;base64," + this._question.image;
    }
  }
}
