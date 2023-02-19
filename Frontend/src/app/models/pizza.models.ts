
export class PizzaDTO{
    id:number = 0;
    pizzaName:string = "";
    toppings:string = "";
    storeId:number = 0;
    price:number = 0;
    pizzaToppings:PizzaToppingDTO[] = [];
}
export class PizzaToppingDTO{
    id:number = 0;
    pizzaId:number = 0;
    toppingId:number = 0;
    toppingName:string = "";
    qty:number = 0;
}