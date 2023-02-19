import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StoreListComponent } from './storeMaintain/store-list/store-list.component';
import { OrderListComponent } from './order/order-list/order-list.component';
import { StoreDetailComponent } from './storeMaintain/store-detail/store-detail.component';
import { OrderDetailComponent } from './order/order-detail/order-detail.component';

const routes: Routes = [
  {
    path:'',
    component:OrderListComponent
  },
  {
    path:'orderlist',
    component:OrderListComponent
  },
  {
    path:'order/:orderId',
    component:OrderDetailComponent
  },
  {
    path:'order',
    component:OrderDetailComponent
  },
  {
    path:'storelist',
    component:StoreListComponent
  },
  {
    path:'store/:storeId',
    component:StoreDetailComponent
  },
  {
    path:'store',
    component:StoreDetailComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes),RouterModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
