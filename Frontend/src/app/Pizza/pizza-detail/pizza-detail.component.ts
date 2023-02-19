import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PizzaService } from '../pizza.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { PizzaDTO } from 'src/app/models/pizza.models';
import { ApiResponse } from 'src/app/models/storeMatintain.models';

@Component({
  selector: 'app-pizza-detail',
  templateUrl: './pizza-detail.component.html'
})
export class PizzaDetailComponent implements OnInit {
  @Input() pizzaId!: number;
  @Input() storeId!: number;
  @Output() closeDetail = new EventEmitter();
  pizzaForm!: FormGroup;
  pizza: PizzaDTO = new PizzaDTO();
  numRegex = /^-?\d*[.,]?\d{0,2}$/;
  prefix: string = 'topping';
  constructor(private pizzaService:PizzaService) { }
  ngOnInit(): void {

    
    this.pizzaForm = new FormGroup({
      pizzaName: new FormControl('', [
        Validators.required
      ]),
      price: new FormControl('', [
        Validators.required,
        Validators.pattern(this.numRegex)
      ])
    });
    
    this.loadPizza();
  }

  get pizzaName() { return this.pizzaForm.get('pizzaName')!; }

  get price() { return this.pizzaForm.get('price')!; }

  loadPizza():void{
    this.pizzaService.getPizza(this.pizzaId).subscribe({
      next:(res)=>{
        this.pizza = res;

        this.pizza.storeId=this.storeId;
        for (let p of res.pizzaToppings) {
          this.pizzaForm.addControl(`${this.prefix}${p.id}`, new FormControl(''));
        }


        console.log(res);
      },
      error:(res)=>{
        console.log(res);
      }
    })
  }
  save(){
    this.pizza.storeId=this.storeId;
    this.pizzaService.savePizza(this.pizza).subscribe({
      next:(res:ApiResponse)=>{
        this.pizzaId = res.responseKey;
        this.loadPizza();
        this.closeDetail.emit();
      },
      error:(res:ApiResponse)=>{
        console.log(res);
      }
    })
  }
}
