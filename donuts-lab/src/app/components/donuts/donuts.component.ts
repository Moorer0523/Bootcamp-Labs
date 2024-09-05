import { Component, inject } from '@angular/core';
import { Donut } from '../../models/donut';
import { DonutAPIService } from '../../services/donut/donut-api.service';
import { DonutResponse } from '../../models/donut-response';
import { DonutCardComponent } from '../donut-card/donut-card.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-donuts',
  standalone: true,
  imports: [DonutCardComponent, CommonModule],
  templateUrl: './donuts.component.html',
  styleUrl: './donuts.component.css',
})
export class DonutsComponent {
  donutList: Donut[] | null = null;
  groupedDonutList = new Array<Donut[]>();
  donutService = inject(DonutAPIService);

  constructor(private donutAPI: DonutAPIService) {}

  ngOnInit() {
    this.loadDonuts();
  }

  loadDonuts() {
    this.donutAPI.getList().subscribe({
      next: (data) => {
        this.donutList = data.results;
        this.splitDonutList()
      },
      error: (error) => {
        console.log(error);
      },
      complete: () => {
        console.log('complete');
      },
    });
  }

  splitDonutList() {
    if (this.donutList?.length != null) {
      for (let i = 0, j = 0; i < this.donutList.length; i++) {
        if (i >= 3 && i % 3 === 0) {
          j++;
        }
        this.groupedDonutList[j] = this.groupedDonutList[j] || [];
        this.groupedDonutList[j].push(this.donutList[i]);
        console.log('loop count:' + i)
      }
    }
    console.log("Donut list Length:", this.donutList?.length)
  }
}
