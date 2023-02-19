import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { OrderDTO } from 'src/app/models/order.models';
import { OrderService } from '../order.service';
import { Location } from '@angular/common'
import { ApiResponse, Store } from 'src/app/models/storeMatintain.models';
import { StoreService } from 'src/app/storeMaintain/store.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PizzaDTO } from 'src/app/models/pizza.models';
import { PizzaService } from 'src/app/Pizza/pizza.service';
import { GlobalService } from 'src/app/global.service';
@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html'
})
export class OrderDetailComponent implements OnInit {

  orderDetailId:number=0;
  orderId!: number;
  // orderForm!: FormGroup;
  order: OrderDTO = new OrderDTO();
  stores:Store[]=[];
  //prefix: string = 'detail';
  pizzas:PizzaDTO[]=[];
  selectedStoreId:number=0;
  isReadOnly:boolean=false;
  constructor(private route: ActivatedRoute,
    private orderService:OrderService,
    private storeService:StoreService,
    private navLocation: Location,
    private modalService: NgbModal,
    private pizzaService:PizzaService,
    private globalService:GlobalService ) {
    
  }
  
  back(): void {
    this.navLocation.back()
  }
  ngOnInit(): void {

    this.storeService.getStoreList().subscribe({
      next:(res)=>{
        this.stores = res;
        this.orderId = this.route.snapshot.params['orderId'];
        this.selectedStoreId=this.stores[0].id;
        this.order.storeId=this.selectedStoreId;
        if(this.orderId){
          this.loadOrder();
          this.isReadOnly=true;
        }
      },
      error:(res)=>{
        console.log(res);
      }
    });

    

  }

  onStoreChange(): void {
    this.order = new OrderDTO();
    this.order.storeId=this.selectedStoreId;
  }

  loadOrder():void{
    this.orderService.getOrder(this.orderId).subscribe({
      next:(res)=>{
        this.orderService.order = res;
        this.order = this.orderService.order;
      },
      error:(res)=>{
        console.log(res);
      }
    })
  }

  isValid():boolean{
    if(this.order.fullName===""){
      this.globalService.AlertMessage("Name is required");
      return false
    }
    if(this.order.adress===""){
      this.globalService.AlertMessage("Address is required");
      return false
    }
    if(this.order.orderDetails.length===0){
      this.globalService.AlertMessage("Please add pizza");
      return false
    }
    return true;
  }

  placeOrder():void{
    if(this.isValid()){
      this.orderService.saveOrder(this.order).subscribe({
        next:(res:ApiResponse)=>{
          this.orderId = res.responseKey;
          this.globalService.AlertMessage("Order Confirmed");
          this.back();
        },
        error:(res:ApiResponse)=>{
          console.log(res);
        }
      })
    }

  }
  add(content: any):void{
    this.orderService.order=this.order;
    this.orderDetailId=0;
    this.pizzaService.getPizzaList(this.order.storeId).subscribe({
      next:(res)=>{
        this.pizzas = res;
        this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
          this.calculateTotal();
        }, (reason) => {
          //this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
        });
      },
      error:(res)=>{
        console.log(res);
      }
    });

  }
  open(content: any,orderDetailId:number) {
    this.orderDetailId = orderDetailId;
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.calculateTotal();
    }, (reason) => {

    });
  }
  calculateTotal():void{
    this.order.total=0;
    this.order.orderDetails.forEach(e => {
      this.order.total=this.order.total+e.price;
    });

  }

}
