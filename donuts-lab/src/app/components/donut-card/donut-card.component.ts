import { Component, Input } from '@angular/core';
import { Donut } from '../../models/donut';



@Component({
  selector: 'app-donut-card',
  standalone: true,
  imports: [],
  templateUrl: './donut-card.component.html',
  styleUrl: './donut-card.component.css'
})
export class DonutCardComponent{

  @Input() donut: Donut | null = null;

}

