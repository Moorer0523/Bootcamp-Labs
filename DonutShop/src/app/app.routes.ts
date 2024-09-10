import { Routes } from '@angular/router';
import { DonutListComponent } from './components/donut-list/donut-list.component';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { DonutDetailComponent } from './components/donut-detail/donut-detail.component';

export const routes: Routes = [
    {path: '', component: DonutListComponent},//blank on the path indicates homepage
    {path: 'about-us', component: AboutUsComponent},
    {path: 'donut-detail/:id', component: DonutDetailComponent} //id is used to indicated a variable
];
