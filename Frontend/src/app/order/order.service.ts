import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Observable } from 'rxjs';
import { OrderDTO } from '../models/order.models';
@Injectable({
  providedIn: 'root'
})
export class OrderService {

  baseApiUrl:string = environment.baseApiUrl;
  order: OrderDTO = new OrderDTO();
  constructor(private http:HttpClient) { }

  getOrderList(): Observable<OrderDTO[]>{
    return this.http.get<OrderDTO[]>(this.baseApiUrl+'/api/order/orderlist')
  }

  getOrder(orderId:number): Observable<OrderDTO>{
    return this.http.get<OrderDTO>(this.baseApiUrl+'/api/order/order/' + orderId)
  }

  saveOrder(order:OrderDTO): Observable<any>{
    return this.http.post<any>(this.baseApiUrl+'/api/order/save/',order);
  }

}
