import { AfterContentInit, Component, Input, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { TaskResultModel } from 'src/app/models/exam-result-model';

@Component({
  selector: 'app-closed-result-template',
  templateUrl: './closed-result-template.component.html',
  styles: ['.mat-icon { vertical-align: middle !important; }']
})
export class ClosedResultTemplateComponent implements AfterContentInit {

  public image: string = null;
  public _result: TaskResultModel;
  public formGroup: FormGroup;
  public selectedOptionIndex: number;
  public resultCorrectness: boolean[];

  @Input() set result(res: TaskResultModel) {
    this.resultCorrectness = [];
    this._result = res;

    this.selectedOptionIndex = res.resultValues.findIndex(x => JSON.parse(x.actual) == true);
    res.resultValues.forEach(x => {
      this.resultCorrectness.push(JSON.parse(x.correct));
    });

    this.formGroup = new FormGroup({
      'option': new FormControl(this.selectedOptionIndex.toString())
    });
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
