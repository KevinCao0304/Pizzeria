export class OrderDetailDTO{
    id:number = 0;
    pizza:string = "";
    pizzaId:number = 0;
    extra:string = "";
    extraTopping:ExtraTopping[]=[];
    price:number = 0;
}
export class ExtraTopping{
    toppingId:number=0;
    qty:number=0;
}
export class OrderDTO{
    id:number = 0;
    fullName:string = "";
    adress:string = "";
    total:number = 0;
    storeId:number = 0;
    storeName:string="";
    orderDetails:OrderDetailDTO[] = [];
}