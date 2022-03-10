import { AfterContentInit, Component, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { FormControl, FormGroup, NgForm } from '@angular/forms';
import { TaskResultModel } from 'src/app/models/exam-result-model';

@Component({
  selector: 'app-yes-no-result-template',
  templateUrl: './yes-no-result-template.component.html',
  styleUrls: ['./yes-no-result-template.component.css']
})
export class YesNoResultTemplateComponent implements AfterContentInit {

  public image: string = null;
  public formGroup = new FormGroup({});
  public _result: TaskResultModel;

  @Input() set result(res: TaskResultModel) {
    this._result = res;
    this.formGroup = new FormGroup({});
    var iter = 0;
    res.resultValues.forEach(value => {
      this.formGroup.addControl('formId_' + iter, new FormControl(value.actual));
      iter++;
    });
    this.loadImage()
  }

  @ViewChild('questionForm') form : NgForm; 

  constructor() {}

  ngAfterContentInit(): void 
  {
    this.loadImage()
  }

  private loadImage() : void 
  {
    if(this._result.image) {
      if(this._result.imageType.toLowerCase() == 'png')
        this.image = "data:image/PNG;base64," + this._result.image;
      else
        this.image = "data:image/JPEG;base64," + this._result.image;
    }
  }
}
