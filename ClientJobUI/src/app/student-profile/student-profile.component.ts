import { Component, OnInit } from '@angular/core';
import {AdvertService} from '../services/advert.service';
import {AdvertDTO} from '../models/DTO/AdvertDTO';
import {MatDialog, MatDialogRef} from '@angular/material/dialog';
import {PopUpComponent} from './pop-up/pop-up.component';

@Component({
  selector: 'app-student-profile',
  templateUrl: './student-profile.component.html',
  styleUrls: ['./student-profile.component.css']
})
export class StudentProfileComponent implements OnInit {

  constructor(private advertService: AdvertService,public dialog: MatDialog) { }
  adverts = [] as AdvertDTO[];
  dialogRef: MatDialogRef<any>;

  ngOnInit(): void {
    this.advertService.getPostedAdverts().subscribe(data =>{this.adverts = data; console.log(data);})
  }

  onClick(advert : AdvertDTO ){
    this.dialogRef = this.dialog.open(PopUpComponent , {
      data : {
        advertObject : advert
      }
    })
  }

  onDelete(advert : AdvertDTO ,id: number){
     this.advertService.deleteAdvert(id).subscribe();
  }





}

