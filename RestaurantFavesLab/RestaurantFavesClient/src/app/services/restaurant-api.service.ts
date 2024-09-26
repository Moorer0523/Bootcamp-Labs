import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderResponse } from '../models/order-response';
import { Order, Orders } from '../models/order';

@Injectable({
  providedIn: 'root'
})
export class RestaurantApiService {

  hostAddress = 'http://localhost:5275/api/'

  status: string ="";
  errorMessage: string ="";

  constructor(private http : HttpClient) { }

  getOrders(): Observable<Orders>{
    return this.http.get<Orders>(this.hostAddress + 'Orders')
  }

  getOrder(id : number): Observable<Order>{
    return this.http.get<Order>(this.hostAddress + `Orders/${id}`)
  }

  putOrder(order : Order): Observable<Order>{
    return this.http.put<Order>(this.hostAddress + `Orders/${order.id}`, order)
  }

  postOrder(order : Order): Observable<Omit<Order,"id">>{
    console.log(order)
    return this.http.post<Order>(this.hostAddress + 'Orders', order)
  }

  deleteOrder(order : Order): boolean{
    console.log(this.hostAddress + `Orders/${order.id}`)
    let response = false
    this.http.delete(this.hostAddress + `Orders/${order.id}`).subscribe({
      next: data => {
          this.status = 'True';
          response = true
      },
      error: (error:HttpErrorResponse) => {
          this.errorMessage = error.message;
          if(error.status === 404)
          console.error('There was an error!', error);
      }
  });

    return response
  }


}
