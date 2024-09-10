import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderResponse } from '../models/order-response';
import { Order, Orders } from '../models/order';

@Injectable({
  providedIn: 'root'
})
export class RestaurantApiService {

  hostAddress = 'http://localhost:5275/api/'
  constructor(private http : HttpClient) { }

  getOrders(): Observable<Orders>{
    return this.http.get<Orders>(this.hostAddress + 'Orders')
  }

  getOrder(id : number): Observable<Order>{
    return this.http.get<Order>(this.hostAddress + `Orders/${id}`)
  }

  putOrder(id : number, order : Order): Observable<Order>{
    const params = {
      id: order.id,
      description: order.description,
      restaurant: order.restaurant,
      rating: order.rating,
      orderAgain: order.orderAgain
    }

    return this.http.put<Order>(this.hostAddress + `Orders/${id}`, {params})
  }

  postOrder(order : Order): Observable<Order>{
    const params = {
      id: order.id,
      description: order.description,
      restaurant: order.restaurant,
      rating: order.rating,
      orderAgain: order.orderAgain
    }
    return this.http.post<Order>(this.hostAddress + 'Orders', {params})
  }

}
