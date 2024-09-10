import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { OrderContainerComponent } from '../order-container/order-container.component';
import { Order } from '../../models/order';
import { RestaurantApiService } from '../../services/restaurant-api.service';

@Component({
  selector: 'app-order',
  standalone: true,
  imports: [CommonModule, OrderContainerComponent],
  templateUrl: './order.component.html',
  styleUrl: './order.component.css'
})
export class OrderComponent {
  order : Order | null = null;
  restaurantService = inject(RestaurantApiService)

  constructor(private restrauntAPi: RestaurantApiService) {}

  ngOnInit() {
    this.loadOrder();
  }

  loadOrder() {
    this.restrauntAPi.getOrder(1).subscribe({
      next: (data) => {
        this.order = data;
      },
      error: (error) => {
        console.log(error);
      },
      complete: () => {
        console.log('complete');
      },
  })
  }
}
