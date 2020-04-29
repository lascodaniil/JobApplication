import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';
import {Observable} from 'rxjs';
import {AdvertDTO} from '../models/DTO/AdvertDTO';



const URL_ADVERT = "http://localhost:5000/Advert"

@Injectable({
  providedIn: 'root'
})
export class AdvertService {

  constructor(private http: HttpClient, private router: Router) {

  }


  getPostedAdvert(): Observable<AdvertDTO>{
    return this.http.get<AdvertDTO[]>(`${URL_ADVERT}`)
  }



}
