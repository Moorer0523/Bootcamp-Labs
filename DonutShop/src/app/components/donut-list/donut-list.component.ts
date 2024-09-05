import { Component, inject } from '@angular/core';
import { Donut } from '../../models/donut';
import { DonutService } from '../../services/donut.service';
import { DonutCardComponent } from "../donut-card/donut-card.component";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-donut-list',
  standalone: true,
  imports: [DonutCardComponent, CommonModule],
  templateUrl: './donut-list.component.html',
  styleUrl: './donut-list.component.css',
})
export class DonutListComponent {
  donutList: Donut[] = [];
  donutService = inject(DonutService);

  ngOnInit() {
    this.loadDonuts();
  }

  loadDonuts() {
    this.donutService.getList().subscribe(
      // (donut) => {
      //   this.donutList = donut.results;
      //   console.log(donut);
      // }
      
        {
        next: (data) => {
          this.donutList = data.results;
        },
        error: (error) => {
          console.log(error);
        },
        complete: () => {
          console.log('complete');
          console.log('Donut list here: ' + this.donutList[0]);
        }
      }
    );
  }
}
