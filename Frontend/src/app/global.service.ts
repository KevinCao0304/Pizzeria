import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { PopupAlertComponent } from './popup-alert/popup-alert.component';
@Injectable({
  providedIn: 'root'
})
export class GlobalService {

  extraToppings:Extra[]=[];
  baseApiUrl:string = environment.baseApiUrl;
  constructor(private http:HttpClient,
    private modalService: NgbModal) { }

  getExtraToppingList(): Observable<Extra[]>{
    return this.http.get<Extra[]>(this.baseApiUrl+'/api/order/extratoppinglist')
  }

  AlertMessage(content:string) {
		const modalRef = this.modalService.open(PopupAlertComponent);
		modalRef.componentInstance.content = content;
    // modalRef.result.then((result) => {

    // }, (reason) => {

    // });
	}
}

export class Extra{
  toppingId:number=0;
  toppingName:string="";
  qty:number=0;
  price:number=0;
}
