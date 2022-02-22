import { AfterContentInit, Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { AnswerModel, AnswerValueModel } from '../../models/answer.model';
import { QuestionModel } from '../../models/question.model';

@Component({
  selector: 'closed-question-template',
  templateUrl: './closed-question-template.component.html'
})
export class ClosedQuestionTemplateComponent implements AfterContentInit, OnInit{

  public image: string = null;
  public _question: QuestionModel;
  public formGroup: FormGroup;

  @Input('question') set question(questionData: QuestionModel) {
    if(this._question)
    {
      if(questionData.taskId != this._question.taskId)
        this.refreshContent(questionData)
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

  ngOnInit(): void {
    this.formGroup = new FormGroup({
      'option': new FormControl('')
    });
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
        answer: (this.formGroup.get('option').value == value.sortId) ? 'true' : 'false'
      };
      answer.values.push(answerValue);
    });

    this.onAnswer.emit(answer);
  }

  private refreshContent(question: QuestionModel) : void 
  {
    this._question = question;
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
