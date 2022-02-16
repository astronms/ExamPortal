import { AfterViewInit, Component, Input, OnDestroy } from '@angular/core';

@Component({
  selector: 'timer-template',
  templateUrl: './timer-template.component.html',
  styleUrls: ['./timer-template.component.css']
})
export class TimerTemplateComponent implements OnDestroy {

  private timeoutId: any;
  private tickCounter: number;
  private afterViewInit: boolean = false;
  public textToDisplay: string;
  
  @Input('startTime') set startTime(secs: number) {
    console.log("SETTTTTTTTTTTTTTTTTTTTTTTT");
    this.tickCounter = secs;
    this.reset();
  }


  constructor() { }

  /*ngAfterViewInit()
  {
    this.startTickCount();
    this.afterViewInit = true;
  }*/

  ngOnDestroy()
  {
    this.stop();
  }

  private startTickCount() : void
  {
    const that = this;
    this.timeoutId = setInterval(function() {
      that.tickCounter--;

      that.renderText();

      if(that.tickCounter <= 0)
        that.stop();

    }, 1000);
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

  private reset() : void
  {
    this.stop();
    //if(this.afterViewInit)
    this.startTickCount();
  }

  private stop() : void
  {
    if (this.timeoutId)
      clearInterval(this.timeoutId);
    
    this.timeoutId = null;
  }

}
