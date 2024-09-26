import { Component, EventEmitter, inject, Output, output } from '@angular/core';
import { Order } from '../../models/order';
import {
  FormsModule,
  FormBuilder,
  ReactiveFormsModule,
  FormGroup,
  FormControl,
  Validators,
} from '@angular/forms';
import { OrderComponent } from '../order/order.component';
import { RestaurantApiService } from '../../services/restaurant-api.service';
import { OrderContainerComponent } from '../order-container/order-container.component';

@Component({
  selector: 'app-add-order-form',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './add-order-form.component.html',
  styleUrl: './add-order-form.component.css',
})
export class AddOrderFormComponent {
  restaurantApi = inject(RestaurantApiService);
  orderForm: FormGroup;
  @Output() update: EventEmitter<Order> = new EventEmitter

  constructor(private formBuilder: FormBuilder) {
    this.orderForm = this.formBuilder.group({
      description: ['', Validators.required],
      restaurant: [''],
      rating: [0],
      orderAgain: [false],
    });
  }

  submitOrder() {
    this.restaurantApi.postOrder(this.orderForm.value).subscribe({
      next: (data) => {
        console.log('Submit Order Success');
      },
      error: (error) => {
        let errorMessage = error.message;
        console.error('There was an error!', errorMessage);
      },
    });

    this.update.emit(this.orderForm.value)
  }
}
