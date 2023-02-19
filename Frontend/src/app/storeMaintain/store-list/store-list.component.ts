import { Component, OnInit } from '@angular/core';

import { Router, RouterModule } from '@angular/router';
import { StoreService } from '../store.service';
import { Store } from 'src/app/models/storeMatintain.models';
import { GlobalService } from 'src/app/global.service';
@Component({
  selector: 'app-store-list',
  templateUrl: './store-list.component.html'
})
export class StoreListComponent implements OnInit {
  constructor(private storeService:StoreService,
    private router: Router,
    private globalService:GlobalService) { }

  stores:Store[]=[];
  ngOnInit(): void {
    this.loadStoreList();
  }
  add():void{
    this.router.navigate(['../store/']);
  }

  loadStoreList(){
    this.storeService.getStoreList().subscribe({
      next:(res)=>{
        this.stores = res;
      },
      error:(res)=>{
        console.log(res);
      }
    });
  }
  
  delete(storeId:number){
    this.storeService.deleteStore(storeId).subscribe({
      next:(res)=>{
        this.loadStoreList();
        this.globalService.AlertMessage("Deleted");
      },
      error:(res)=>{
        console.log(res);
      }
    });
  }

}
