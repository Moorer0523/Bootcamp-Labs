import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderResponse } from '../models/order-response';

@Injectable({
  providedIn: 'root'
})
export class RestaurantApiService {

  hostAddress = 'http://localhost:5275/api/'
  constructor(private http : HttpClient) { }

  getList(): Observable<OrderResponse>{
    return this.http.get<OrderResponse>(this.hostAddress + 'Orders')
  }
}
