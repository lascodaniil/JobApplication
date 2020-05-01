import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {PopUpData} from '../../_models/PopUpData';
import {PopUpComponent} from '../pop-up/pop-up.component';
import {AdvertService} from '../../_services/advert.service';
import {AdvertDTO} from '../../_models/DTO/AdvertDTO';
import {CityDTO} from '../../_models/DTO/CityDTO';
import {JobService} from '../../_services/job.service';

@Component({
  selector: 'app-update-advert',
  templateUrl: './update-advert.component.html',
  styleUrls: ['./update-advert.component.css']
})
export class UpdateAdvertComponent implements OnInit {

  advert: AdvertDTO;
  cities: CityDTO[];


  constructor(public dialogRef: MatDialogRef<PopUpComponent>,
              @Inject(MAT_DIALOG_DATA) public popup: PopUpData,
              private advertService: AdvertService,
              private jobService : JobService
              ) { }

  ngOnInit(): void {
      this.jobService.getCity().subscribe(data=>{this.cities = data;})
      this.advertService.getPostedAdvert(this.popup.advertObject.advertId).subscribe(data=>{this.advert=data; console.log(this.advert)});
  }

  onUpdate(advert:AdvertDTO , id:number) {
    this.advertService.putAdvert(advert, id).subscribe(() => {
      this.dialogRef.close();
    });
  }

}
