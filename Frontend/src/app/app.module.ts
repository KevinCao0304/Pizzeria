import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { OrderDetailComponent } from './order/order-detail/order-detail.component';
import { OrderListComponent } from './order/order-list/order-list.component';
import { StoreDetailComponent } from './storeMaintain/store-detail/store-detail.component';
import { StoreListComponent } from './storeMaintain/store-list/store-list.component';
import { PizzaListComponent } from './Pizza/pizza-list/pizza-list.component';
import { PizzaDetailComponent } from './Pizza/pizza-detail/pizza-detail.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ChoosePizzaComponent } from './order/choose-pizza/choose-pizza.component';
import { PopupAlertComponent } from './popup-alert/popup-alert.component';

@NgModule({
  declarations: [
    AppComponent,
    OrderDetailComponent,
    OrderListComponent,
    StoreDetailComponent,
    StoreListComponent,
    PizzaListComponent,
    PizzaDetailComponent,
    ChoosePizzaComponent,
    PopupAlertComponent
  ],
  imports: [
    BrowserModule,
    RouterModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule ,
    NgbModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
