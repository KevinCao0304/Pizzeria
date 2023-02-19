import { Component, Input, OnInit } from '@angular/core';
import { PizzaService } from '../pizza.service';
import { Router } from '@angular/router';
import { PizzaDTO } from 'src/app/models/pizza.models';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { GlobalService } from 'src/app/global.service';

@Component({
  selector: 'app-pizza-list',
  templateUrl: './pizza-list.component.html'
})
export class PizzaListComponent implements OnInit  {
  constructor(private pizzaService:PizzaService,
    private router: Router,
    private modalService: NgbModal,
    private globalService:GlobalService) { }
    pizzas:PizzaDTO[]=[];
    @Input() storeId! : number;
    pizzaId: number = 0;
  ngOnInit(): void {
    this.loadPizzaList();
  }
  loadPizzaList(){
    this.pizzaService.getPizzaList(this.storeId).subscribe({
      next:(res)=>{
        this.pizzas = res;
      },
      error:(res)=>{
        console.log(res);
      }
    });
  }
  add(content: any):void{
    this.pizzaId = 0;
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      //this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
      //this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }
  open(content: any,pizzaId:number) {
    this.pizzaId = pizzaId;
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {

    }, (reason) => {

    });
  }

  closeDetail(){
    this.loadPizzaList();
  }

  delete(pizzaId:number){
    this.pizzaService.deletePizza(pizzaId).subscribe({
      next:(res)=>{
        this.loadPizzaList();
        this.globalService.AlertMessage("Deleted");
      },
      error:(res)=>{
        console.log(res);
      }
    });
  }
}
