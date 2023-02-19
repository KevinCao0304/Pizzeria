export class Store{
    id:number=0;
    storeName:string="";
    location:string="";
}

export interface ApiResponse
{
    responseMessage:string;
    responseKey:number;
}