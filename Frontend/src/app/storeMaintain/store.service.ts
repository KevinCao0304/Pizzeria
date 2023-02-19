import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { Store } from '../models/storeMatintain.models';
@Injectable({
  providedIn: 'root'
})
export class StoreService {

  baseApiUrl:string = environment.baseApiUrl;
  constructor(private http:HttpClient) { }

  getStoreList(): Observable<Store[]>{
    return this.http.get<Store[]>(this.baseApiUrl+'/api/store/storelist')
  }

  getStore(storeId:number): Observable<Store>{
    return this.http.get<Store>(this.baseApiUrl+'/api/store/store/' + storeId)
  }

  saveStore(store:Store): Observable<any>{
    return this.http.post<any>(this.baseApiUrl+'/api/store/save/',store);
  }

  deleteStore(storeId:number): Observable<any>{
    return this.http.delete<any>(this.baseApiUrl+'/api/store/delete/' + storeId);
  }
}
