import {Component, EventEmitter, Inject, OnInit, Optional, Output} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {AddJobData} from '../../_models/AddJobData';
import {PopUpData} from '../../_models/PopUpData';
import {PaginatedRequest} from '../../_models/PaginatedRequest';
import {AdvertService} from '../../_services/advert.service';

@Component({
  selector: 'app-pop-up',
  templateUrl: './pop-up.component.html',
  styleUrls: ['./pop-up.component.css']
})
export class PopUpComponent{
  constructor(public dialogRef: MatDialogRef<PopUpComponent>,@Inject(MAT_DIALOG_DATA) public popup: PopUpData, private advert: AdvertService) { }
  onDelete(){
    this.advert.deleteAdvert(this.popup.advertObject.advertId).subscribe();
    this.dialogRef.close();
  }
}



