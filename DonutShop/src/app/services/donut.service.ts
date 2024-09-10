import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DonutResponse } from '../models/donut-response';
import { DonutDetail } from '../models/donut-detail';

@Injectable({
  providedIn: 'root'
})
export class DonutService {

  constructor(private http : HttpClient) { }

  getList(): Observable<DonutResponse>{
    return  this.http.get<DonutResponse>("https://grandcircusco.github.io/demo-apis/donuts.json")
  }

  getDonutById(id:number): Observable<DonutDetail> {
    return this.http.get<DonutDetail>(`https://grandcircusco.github.io/demo-apis/donuts/${id}.json`)
  }

}
