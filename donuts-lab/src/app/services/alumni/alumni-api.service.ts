import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AlumniResponse } from '../../models/alumni-response';

@Injectable({
  providedIn: 'root'
})
export class AlumniAPIService {

  constructor(private http : HttpClient) { }

  getList(): Observable<AlumniResponse>{
    return  this.http.get<AlumniResponse>('https://grandcircusco.github.io/demo-apis/computer-science-hall-of-fame.json')
  }
}
