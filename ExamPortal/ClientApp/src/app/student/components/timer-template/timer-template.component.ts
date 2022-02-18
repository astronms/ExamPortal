import { AfterViewInit, Component, Input, OnDestroy, OnInit } from '@angular/core';
import { SyncExamService } from '../../services/sync-exam.service';

@Component({
  selector: 'timer-template',
  templateUrl: './timer-template.component.html',
  styleUrls: ['./timer-template.component.css']
})
export class TimerTemplateComponent implements OnInit {

  private tickCounter: number;
  public textToDisplay: string;

  constructor(
    private examService: SyncExamService
  ) { }

  ngOnInit(): void {
      
  }

  setQuestionListener()
  {
    this.examService.questionTime.subscribe(time => {
      this.tickCounter = time;
      this.renderText();
    });
  }

  private renderText() : void
  {
    var mins = Math.floor(this.tickCounter / 60);
    var secs = Math.floor(this.tickCounter - (mins * 60));
    var out = '';

    if(mins > 4)
      out += mins + ' minut ';
    else if(mins > 1 && mins <= 4)
      out += mins + ' minuty ';
    else if(mins == 1)
      out += mins + ' minuta ';

    if(secs > 4 || secs == 0)
      out += secs + ' sekund';
    else if(secs > 1 && secs <= 4)
      out += secs + ' sekundy';
    else
      out += secs + ' sekunda';

    this.textToDisplay = out;
  }
}
