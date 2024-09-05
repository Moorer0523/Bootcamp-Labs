import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DonutListComponent } from "./components/donut-list/donut-list.component";
import { DonutCardComponent } from "./components/donut-card/donut-card.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, DonutListComponent, DonutCardComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'DonutShop';
}
