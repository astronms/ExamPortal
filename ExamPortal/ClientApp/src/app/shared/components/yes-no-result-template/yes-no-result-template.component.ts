import { AfterContentInit, Component, Input} from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
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
  public resultCorrectness: boolean[];

  @Input() set result(res: TaskResultModel) {
    this._result = res;
    this.resultCorrectness = [];
    this.formGroup = new FormGroup({});
    var iter = 0;
    res.resultValues.forEach(value => {
      this.formGroup.addControl('formId_' + iter, new FormControl(JSON.parse(value.actual)));
      iter++; 
      if(JSON.parse(value.actual) == JSON.parse(value.correct))
        this.resultCorrectness.push(true);
      else
        this.resultCorrectness.push(false);
    });
    this.loadImage()
  }

  constructor() {}

  ngAfterContentInit(): void 
  {
    this.loadImage()
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
