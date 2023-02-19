import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { PizzaDTO } from '../models/pizza.models';

@Injectable({
  providedIn: 'root'
})
export class PizzaService {

  baseApiUrl:string = environment.baseApiUrl;
  constructor(private http:HttpClient) { }
  
  getPizzaList(pizzaId:number): Observable<PizzaDTO[]>{
    return this.http.get<PizzaDTO[]>(this.baseApiUrl+'/api/pizza/pizzalist/' + pizzaId)
  }

  getPizza(pizzaId:number): Observable<PizzaDTO>{
    return this.http.get<PizzaDTO>(this.baseApiUrl+'/api/pizza/pizza/' + pizzaId)
  }

  savePizza(pizza:PizzaDTO): Observable<any>{
    return this.http.post<any>(this.baseApiUrl+'/api/pizza/save/',pizza);
  }

  deletePizza(pizzaId:number): Observable<any>{
    return this.http.delete<any>(this.baseApiUrl+'/api/pizza/delete/' + pizzaId);
  }
}
