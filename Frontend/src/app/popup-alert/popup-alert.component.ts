import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-popup-alert',
  templateUrl: './popup-alert.component.html'
})
export class PopupAlertComponent {
	@Input() content="";

	constructor(public activeModal: NgbActiveModal) {}
}
