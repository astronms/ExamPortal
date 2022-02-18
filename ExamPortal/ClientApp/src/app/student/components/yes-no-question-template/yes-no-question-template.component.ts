import { AfterContentInit, Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { AnswerModel, AnswerValueModel } from '../../models/answer.model';
import { QuestionModel } from '../../models/question.model';

@Component({
  selector: 'yes-no-question-template',
  templateUrl: './yes-no-question-template.component.html',
  styleUrls: ['./yes-no-question-template.component.css']
})
export class YesNoQuestionTemplateComponent implements AfterContentInit {

  public image: string = null;
  public _question: QuestionModel;
  public formGroup = new FormGroup({});

  @Input('question') set question(q: QuestionModel)
  {
    if(this._question)
    {
      if(q.taskId != this._question.taskId)
      {
        this._question = q;
        this.formGroup = new FormGroup({});
        this._question.values.forEach(value => {
          this.formGroup.addControl('formId_' + value.sortId, new FormControl(''));
        });
        this.loadImage()
        if(this.form)
          this.form.reset();
      }
    }
    else
    {
      this._question = q;
      this.formGroup = new FormGroup({});
      this._question.values.forEach(value => {
        this.formGroup.addControl('formId_' + value.sortId, new FormControl(''));
      });
      this.loadImage()
      if(this.form)
        this.form.reset();
    }
  }
  @Output('onAnswer') onAnswer: EventEmitter<AnswerModel> = new EventEmitter<AnswerModel>();
  @ViewChild('questionForm') form : NgForm; 

  constructor() {}

  ngAfterContentInit(): void 
  {
    this.loadImage()
  }

  onSubmit()
  {
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
