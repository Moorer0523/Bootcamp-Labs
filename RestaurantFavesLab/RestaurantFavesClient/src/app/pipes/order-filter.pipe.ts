import { Pipe, PipeTransform } from '@angular/core';
import { Order } from '../models/order';

@Pipe({
  name: 'orderFilter',
  standalone: true
})
export class OrderFilterPipe implements PipeTransform {

  transform(value: Array<Order>,filter: string): Array<Order> {
    return filter ? value.filter(x => 
      x.description.toLowerCase().includes(filter.toLowerCase()) ||
      x.restaurant.toLowerCase().includes(filter.toLowerCase()) ||
      x.rating == parseInt(filter)
    ): value;
  }

}
