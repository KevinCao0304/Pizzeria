import { AfterViewInit, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Location } from '@angular/common'
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { StoreService } from '../store.service';
import { ApiResponse, Store } from 'src/app/models/storeMatintain.models';
import { GlobalService } from 'src/app/global.service';

@Component({
  selector: 'app-store-detail',
  templateUrl: './store-detail.component.html'
})
export class StoreDetailComponent implements OnInit,AfterViewInit {
  storeId!: number;
  storeForm!: FormGroup;
  store: Store=new Store();
  constructor(private route: ActivatedRoute,
    private storeService:StoreService,
    private navLocation: Location,
    private cdr: ChangeDetectorRef,
    private globalService:GlobalService ) {
    
  }
  ngAfterViewInit(): void {
    
  }
  back(): void {
    this.navLocation.back()
  }
  ngOnInit(): void {
    this.storeId = this.route.snapshot.params['storeId'];
    this.storeForm = new FormGroup({
      storeName: new FormControl('', [
        Validators.required
      ]),
      location: new FormControl('', [
        Validators.required
      ])
    });

    if(this.storeId){
      this.loadStore();
    }
  }
  loadStore():void{
    this.storeService.getStore(this.storeId).subscribe({
      next:(res)=>{
        this.store = res;
        this.cdr.detectChanges();
      },
      error:(res)=>{
        console.log(res);
      }
    });
  }
  get storeName() { return this.storeForm.get('storeName')!; }

  get location() { return this.storeForm.get('location')!; }

  save(){
    this.storeService.saveStore(this.store).subscribe({
      next:(res:ApiResponse)=>{
        this.storeId = res.responseKey;
        this.globalService.AlertMessage("Saved");
        this.loadStore();
      },
      error:(res:ApiResponse)=>{
        console.log(res);
      }
    })
  }
}
