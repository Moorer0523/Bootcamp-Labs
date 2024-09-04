import { Component } from '@angular/core';
import { Donut } from '../../models/donut';
import { DonutAPIService } from '../../services/donut/donut-api.service';

@Component({
  selector: 'app-donuts',
  standalone: true,
  imports: [],
  templateUrl: './donuts.component.html',
  styleUrl: './donuts.component.css'
})
export class DonutsComponent {

  siteLists : Donut

  constructor(private donutAPI: DonutAPIService) {}

  
  ngOnInit() {
    this.donutAPI.getList().subscribe({
      next: (data) => {
        this.siteLists = data
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
