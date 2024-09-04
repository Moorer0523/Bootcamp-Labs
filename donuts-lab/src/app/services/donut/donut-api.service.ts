import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Donut } from '../../models/donut';

@Injectable({
  providedIn: 'root'
})
export class DonutAPIService {

  constructor(private http : HttpClient) { }

  getList(): Observable<Donut>{
    return this.http.get<Donut>('https://grandcircusco.github.io/demo-apis/donuts.json')
  }
}
