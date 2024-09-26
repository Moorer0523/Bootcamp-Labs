import { Component, inject } from '@angular/core';
import { Order } from '../../models/order';
import { RestaurantApiService } from '../../services/restaurant-api.service';
import { CommonModule } from '@angular/common';
import { OrderComponent } from '../order/order.component';
import { OrderFilterPipe } from '../../pipes/order-filter.pipe';
import { FormsModule } from '@angular/forms';
import { AddOrderFormComponent } from "../add-order-form/add-order-form.component";

@Component({
  selector: 'app-order-container',
  standalone: true,
  imports: [CommonModule, OrderComponent, OrderFilterPipe, FormsModule, AddOrderFormComponent],
  templateUrl: './order-container.component.html',
  styleUrl: './order-container.component.css',
})
export class OrderContainerComponent {
  orders: Order[] = [];
  restaurantService = inject(RestaurantApiService);

  filterInput = '';

  constructor(private restaurantApi: RestaurantApiService) {}

  ngOnInit() {
    this.loadOrders();
  }

  ngOnChanges() {
    console.log('changes are happening');
    this.loadOrders();
  }

  loadOrders() {
    this.restaurantApi.getOrders().subscribe({
      next: (data) => {
        this.orders = data;
      },
      error: (error) => {
        console.log(error);
      },
      complete: () => {
        console.log('complete');
      },
    });
  }

  deleteOrder(order: Order) {
    if (order != null) {
      if (this.restaurantApi.deleteOrder(order)) {
        const index = this.orders.indexOf(order, 0);
        this.orders.splice(index, 1);
      }
      //need to figure out what to do if it fails to delete
    }
  }

  addNewOrder(input: Order) {
    this.orders.push(input)
  }
}
