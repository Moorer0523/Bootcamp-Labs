import { Pipe, PipeTransform } from '@angular/core';
import { Todo } from '../../models/todo';

@Pipe({
  name: 'tableFilter',
  standalone: true
})
export class TableFilterPipe implements PipeTransform {

  transform(value: Array<Todo>, filter: string): Array<Todo> {

    return filter ? value.filter(x => x.task.toLowerCase().includes(filter.toLowerCase())): value;
  }

}
