import { Component, Input } from '@angular/core';
import { Donut } from '../../models/donut';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-donut-card',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './donut-card.component.html',
  styleUrl: './donut-card.component.css'
})
export class DonutCardComponent {
  //data from parent to child
  @Input() donut : Donut | null = null

  
}
