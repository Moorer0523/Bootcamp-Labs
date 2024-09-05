import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Donut } from '../models/donut';
import { DonutResponse } from '../models/donut-response';

@Injectable({
  providedIn: 'root'
})
export class DonutService {

  constructor(private http : HttpClient) { }

  getList(): Observable<DonutResponse>{
    return  this.http.get<DonutResponse>("https://grandcircusco.github.io/demo-apis/donuts.json")
  }

}
