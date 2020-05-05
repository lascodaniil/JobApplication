import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {AdvertData} from '../../_models/AdvertData';
import {CategoryDTO} from '../../_models/DTO/CategoryDTO';
import {CityDTO} from '../../_models/DTO/CityDTO';
import {AdvertDTO} from '../../_models/DTO/AdvertDTO';
import {AdvertService} from '../../_services/advert.service';

@Component({
  selector: 'app-update-advert',
  templateUrl: './update-advert.component.html',
  styleUrls: ['./update-advert.component.css']
})
export class UpdateAdvertComponent implements OnInit {

  categories: CategoryDTO[];
  cities: CityDTO[];
  advert = {} as AdvertDTO;

  constructor(@Inject(MAT_DIALOG_DATA) public advertData: AdvertData,
              public dialogRef: MatDialogRef<UpdateAdvertComponent>, private advertService : AdvertService) { }

  ngOnInit(): void {
    this.categories = this.advertData.categories;
    this.cities = this.advertData.cities;

      this.advertService.getPostedAdvert(this.advertData.id).subscribe(data => {this.advert = data});

    }

    onUpdateAdvert(advert ,id) {
    this.advertService.putAdvert(advert, id).subscribe(() => {
      this.dialogRef.close();
    });
    }
}
