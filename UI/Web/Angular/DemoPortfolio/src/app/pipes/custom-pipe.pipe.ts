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
  name: 'customCapitalize',
  //pure: true
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

@Pipe({
  name: "sortArray"
})
export class ArraySortPipe implements PipeTransform {
  transform(array: any, field: string): any[] {
    if (!Array.isArray(array)) {
      return array;
    }
    array.sort((a: any, b: any) => {
      if (a[field] < b[field]) {
        return -1;
      } else if (a[field] > b[field]) {
        return 1;
      } else {
        return 0;
      }
    });
    return array;
  }
}
