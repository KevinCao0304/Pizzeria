import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OrderDTO } from 'src/app/models/order.models';
import { OrderService } from '../order.service';
import { GlobalService } from 'src/app/global.service';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html'
})
export class OrderListComponent implements OnInit {

  orders:OrderDTO[]=[];

  constructor(private orderService:OrderService,
    private router: Router,
    private globalService:GlobalService) { }

  ngOnInit(): void {
    this.loadOrderList();

    this.globalService.getExtraToppingList().subscribe({
      next:(res)=>{
        this.globalService.extraToppings = res;
        console.log(res);
      },
      error:(res)=>{
        console.log(res);
      }
    })
  }

  loadOrderList(){
    this.orderService.getOrderList().subscribe({
      next:(res)=>{
        this.orders = res;
      },
      error:(res)=>{
        console.log(res);
      }
    });
  }

  add():void{
    this.router.navigate(['../order']);
  }
}
