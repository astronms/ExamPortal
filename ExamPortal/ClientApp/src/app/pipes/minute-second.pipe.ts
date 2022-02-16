import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'minuteSeconds'
})
export class MinuteSecondsPipe implements PipeTransform {

    transform(value: number): string {
        const minutes: number = Math.floor(value / 60);
        const secs: number = value - minutes * 60;
        let ret = '';
        if(minutes == 1)
            ret += minutes + ' minuta ';
        else if(minutes > 1 && minutes < 5)
            ret += minutes + ' minuty ';
        else if(minutes >= 5)
            ret += minutes + ' minut';

        if(secs == 1)
            ret += secs + ' sekunda';
        else if(secs > 1 && secs < 5)
            ret += secs + ' sekundy';
        else if(secs >= 5)
            ret += secs + ' sekund';

        return ret;
    }

}