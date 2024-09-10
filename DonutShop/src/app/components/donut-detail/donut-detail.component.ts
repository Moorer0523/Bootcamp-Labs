import { Component, inject } from '@angular/core';
import { DonutDetail } from '../../models/donut-detail';
import { DonutService } from '../../services/donut.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-donut-detail',
  standalone: true,
  imports: [],
  templateUrl: './donut-detail.component.html',
  styleUrl: './donut-detail.component.css'
})
export class DonutDetailComponent {

  donutDetail: DonutDetail | null = null;

  donutService = inject(DonutService)
  route = inject(ActivatedRoute) // grabs the number out of the URL

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get("id")

    if(id){
      this.getDonutById(Number(id))
    }
  }


  getDonutById(id:number) {
    this.donutService.getDonutById(id).subscribe(
      (donutDetail) => {
        this.donutDetail = donutDetail
      }
    )
  }

}
