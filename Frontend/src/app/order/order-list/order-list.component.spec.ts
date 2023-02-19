import { ComponentFixture, TestBed } from '@angular/core/testing';
import { OrderListComponent } from './order-list.component';
21

import { HttpClientTestingModule, } from '@angular/common/http/testing';
import {HttpClientModule} from '@angular/common/http';
import { OrderService } from '../order.service';
import { Router } from '@angular/router';
import { GlobalService } from 'src/app/global.service';



describe('OrderListComponent', () => {
  let component: OrderListComponent;
  let fixture: ComponentFixture<OrderListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
        imports: [HttpClientTestingModule], 
        providers: [OrderService,Router,GlobalService],
      declarations: [ OrderListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OrderListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
