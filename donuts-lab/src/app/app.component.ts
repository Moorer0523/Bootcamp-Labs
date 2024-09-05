import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DonutsComponent } from './components/donuts/donuts.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, DonutsComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'donuts-lab';
}
