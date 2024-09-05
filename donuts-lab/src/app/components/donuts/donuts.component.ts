import { Component } from '@angular/core';
import { Donut } from '../../models/donut';
import { DonutAPIService } from '../../services/donut/donut-api.service';
import { DonutResponse } from '../../models/donut-response';

@Component({
  selector: 'app-donuts',
  standalone: true,
  imports: [],
  templateUrl: './donuts.component.html',
  styleUrl: './donuts.component.css'
})
export class DonutsComponent {

  donutList : Donut[] | null = null
  constructor(private donutAPI: DonutAPIService) {}

  
  ngOnInit() {
    this.donutAPI.getList().subscribe({
      next: (data) => {
        this.donutList = data.results
      },
      error: (error) => {
        console.log(error)
      },
      complete: () => {
        console.log('complete')
      }
    })
  }
}
