import { AfterContentInit, Component, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators, NgForm } from '@angular/forms';
import { ResultValueModel, TaskResultModel } from 'src/app/models/exam-result-model';


@Component({
  selector: 'app-open-result-template',
  templateUrl: './open-result-template.component.html',
  styleUrls: ['./open-result-template.component.css']
})
export class OpenResultTemplateComponent implements AfterContentInit {

  public image: string = null;
  public _result: TaskResultModel;
  public formGroup = new FormGroup({});
  public resultCorrectness: boolean[];

  @Input() set result(res: TaskResultModel) {
    this._result = res;
    this.resultCorrectness = [];
    var index = 0;
    res.resultValues.forEach(value => {
      this.formGroup.addControl('formId_' + index, new FormControl(value.actual));
      var correctness = value.actual.trim() == value.correct.trim();
      this.resultCorrectness.push(correctness);
      index++;
    });
    this.loadImage();
  };

  constructor() {}

  ngAfterContentInit(): void 
  {
    this.loadImage();
  }

  private loadImage() : void 
  {
    if(this._result.image && this._result.imageType) {
      if(this._result.imageType.toLowerCase() == 'png')
        this.image = "data:image/PNG;base64," + this._result.image;
      else
        this.image = "data:image/JPEG;base64," + this._result.image;
    }
  }
}
