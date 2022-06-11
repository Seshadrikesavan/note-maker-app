import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'modified'
})
export class ModifiedPipe implements PipeTransform {

  transform(value: Date, ...args: unknown[]): string {
    let timeDifference: number = new Date().getTime() - new Date(value).getTime();
    let timeDifferenceInSec: number = Math.floor(timeDifference/1000);
    let timeDifferenceInMin: number = Math.floor(timeDifferenceInSec/60);
    let timeDifferenceInHour: number = Math.floor(timeDifferenceInMin/60);
    let timeDifferenceInDay: number = Math.floor(timeDifferenceInHour/24 );
    let timeDifferenceInMonth: number = Math.floor(timeDifferenceInDay/30);
    let timeDifferenceInYear: number = Math.floor(timeDifferenceInMonth/12);
    if(timeDifferenceInYear > 0)
      return timeDifferenceInYear.toString() + 'y';
    else if(timeDifferenceInMonth > 0)
      return timeDifferenceInMonth + 'mo';
    else if(timeDifferenceInDay > 0)
      return timeDifferenceInDay.toString() + 'd';
    else if(timeDifferenceInHour > 0)
      return timeDifferenceInHour.toString() + 'h';
    else if(timeDifferenceInMin > 0)
      return timeDifferenceInMin.toString() + 'min';
    else
      return timeDifferenceInSec.toString() + 's';
    
  }

}
function floor(arg0: number) {
  throw new Error('Function not implemented.');
}

