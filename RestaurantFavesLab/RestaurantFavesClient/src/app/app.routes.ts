import { Routes } from '@angular/router';
import { OrderContainerComponent } from './components/order-container/order-container.component';
import { OrderComponent } from './components/order/order.component';

export const routes: Routes = [
    {path: '', component: OrderContainerComponent},
    {path: 'order-detail/:id', component: OrderComponent}
];
