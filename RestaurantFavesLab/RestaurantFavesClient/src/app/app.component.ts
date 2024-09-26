import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { OrderComponent } from './components/order/order.component';
import { OrderContainerComponent } from './components/order-container/order-container.component';
import { AddOrderFormComponent } from "./components/add-order-form/add-order-form.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, OrderComponent, OrderContainerComponent, AddOrderFormComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'RestaurantFavesClient';
}
