import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'customPipe'
})
export class CustomPipePipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}

@Pipe({
  name: 'customCapitalize'
})
export class CustomCapitalize implements PipeTransform {

  transform(value: string, isTitleCase: boolean): string {

    if (value) {

      value = value.toLocaleLowerCase();

      if (isTitleCase) {

        value = value.replace(/\w\S*/g, function (txt) {

          return txt.charAt(0).toUpperCase() + txt.substr(1).toLowerCase();
        });

      } else {

        value = value.charAt(0).toUpperCase() + value.slice(1);
      }     
    }

    console.log("pipe transform: ", value);
    return value;
  }

}
