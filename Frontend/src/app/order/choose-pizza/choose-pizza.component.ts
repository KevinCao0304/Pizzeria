import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PizzaDTO } from 'src/app/models/pizza.models';
import { OrderService } from '../order.service';
import { ExtraTopping, OrderDTO, OrderDetailDTO } from 'src/app/models/order.models';
import { Extra, GlobalService } from 'src/app/global.service';

@Component({
  selector: 'app-choose-pizza',
  templateUrl: './choose-pizza.component.html'
})
export class ChoosePizzaComponent implements OnInit  {

  @Input()  pizzas:PizzaDTO[]=[];
  @Input() id:number=0;
  @Output() closeDetail = new EventEmitter();
  pizzaPrice:number=0;
  order: OrderDTO = new OrderDTO();
  orderDetail: OrderDetailDTO =new OrderDetailDTO();
  selectedPizzaId:number=0;
  selectedPizza:PizzaDTO=new PizzaDTO();
  toppings:string | undefined;
  extraToppings:Extra[]=[];
  constructor(private route: ActivatedRoute,
    private orderService:OrderService,
    private globalService:GlobalService ) {
    this.extraToppings = this.globalService.extraToppings;

  }
  
  ngOnInit(): void {

    this.toppings = this.pizzas[0].toppings;
    this.order = this.orderService.order;
    if(this.id!==0){

      this.orderDetail = this.order.orderDetails.find(x=>x.id===this.id) as OrderDetailDTO;
      this.selectedPizzaId = this.orderDetail.pizzaId;
      this.selectedPizza=this.pizzas.find(x=>x.id===this.selectedPizzaId) as PizzaDTO;
      this.extraToppings.forEach(e => {
        e.qty = 0;
        var extraTopping= this.orderDetail.extraTopping.find(x=>x.toppingId===e.toppingId) as ExtraTopping;
        if(extraTopping){
          e.qty= extraTopping.qty;
        }
      });
    }else{
      this.selectedPizzaId = this.pizzas[0].id;
      this.selectedPizza=this.pizzas.find(x=>x.id===this.selectedPizzaId) as PizzaDTO;
      this.extraToppings.forEach(e => {
        e.qty = 0;
      });
      this.orderDetail =new OrderDetailDTO();
    }
    this.calculatePrice();
  }

  onPizzaChange(): void {

    this.selectedPizza=this.pizzas.find(x=>x.id===this.selectedPizzaId) as PizzaDTO;
    this.toppings = this.selectedPizza.toppings;
    this.orderDetail.pizzaId = this.selectedPizzaId;
    this.calculatePrice();
  }
  onToppingChange():void{
    this.calculatePrice();
  }
  addToOrder():void{
    if(this.id === 0){
      this.id=this.order.orderDetails.length+1;
      this.orderDetail.id=this.id;
      this.orderDetail.pizza=this.selectedPizza.pizzaName+this.selectedPizza.toppings;
      this.orderDetail.pizzaId=this.selectedPizzaId;

      
      this.orderDetail.extraTopping=this.extraToppings
      .filter(x=>x.qty>0)
      .map(x=>{
          let et: ExtraTopping = { toppingId: x.toppingId, qty: x.qty};
          return et;
      });

      this.extraToppings.forEach(e => {
        if(e.qty>0){
          this.orderDetail.extra=this.orderDetail.extra+e.toppingName+"*"+e.qty+" ";
        }
      });
      
      this.orderDetail.price=this.pizzaPrice;
      this.order.orderDetails.push(this.orderDetail);
    }else{
      this.orderDetail.id=this.id;
      this.orderDetail.pizza=this.selectedPizza.pizzaName+this.selectedPizza.toppings;
      this.orderDetail.pizzaId=this.selectedPizzaId;

      
      this.orderDetail.extraTopping=this.extraToppings
      .filter(x=>x.qty>0)
      .map(x=>{
          let et: ExtraTopping = { toppingId: x.toppingId, qty: x.qty};
          return et;
      });

      this.extraToppings.forEach(e => {
        if(e.qty>0){
          this.orderDetail.extra=this.orderDetail.extra+e.toppingName+"*"+e.qty+" ";
        }
      });
      
      this.orderDetail.price=this.pizzaPrice;
    }
    this.closeDetail.emit();
  }
  calculatePrice():void{
    this.pizzaPrice=this.selectedPizza.price;
    this.extraToppings.forEach(e => {
      this.pizzaPrice=this.pizzaPrice+(e.qty*e.price);
    });

  }
}
