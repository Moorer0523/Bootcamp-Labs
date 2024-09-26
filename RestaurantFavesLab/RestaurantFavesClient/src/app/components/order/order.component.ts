import { CommonModule } from '@angular/common';
import { Component, inject, Input, ChangeDetectionStrategy, Output, EventEmitter } from '@angular/core';
import { OrderContainerComponent } from '../order-container/order-container.component';
import { Order } from '../../models/order';
import { RestaurantApiService } from '../../services/restaurant-api.service';

@Component({
  selector: "[app-order-row]",
  standalone: true,
  imports: [CommonModule, OrderContainerComponent],
  templateUrl: './order.component.html',
  styleUrl: './order.component.css'
})
export class OrderComponent {

  @Input() order : Order | null = null

  @Input() index : number = 0

  @Output() delete: EventEmitter<Order> = new EventEmitter

  restaurantApi = inject(RestaurantApiService)

  postOrder() {
    if (this.order != null)
      this.restaurantApi.postOrder(this.order)
  }

  putOrder() {
    if(this.order != null)
      this.restaurantApi.putOrder(this.order)
  }

  deleteOrder() {
    if(this.order != null){
      this.delete.emit(this.order)
    }

  }
}
