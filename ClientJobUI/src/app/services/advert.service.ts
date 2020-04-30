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

  constructor(private http: HttpClient, private router: Router) { }

  getPostedAdverts(): Observable<AdvertDTO[]>{
    return this.http.get<AdvertDTO[]>(`${URL_ADVERT}`);
  }

  getStudentAdverts() : Observable<AdvertDTO[]> {
    return this.http.get<AdvertDTO[]>(`${URL_ADVERT}/Student/Adverts`);
  }

  postStudentAdverts( advert : AdvertDTO ) : Observable<AdvertDTO[]>{
    return this.http.post<AdvertDTO[]>(`${URL_ADVERT}`, advert);
  }
  getPostedAdvert(advertId: number): Observable<AdvertDTO>{
    return this.http.get<AdvertDTO>(`${URL_ADVERT}`);
  }

  putAdvert(advert: AdvertDTO, advertId : number): Observable<any>{
    return this.http.put<any>(`${URL_ADVERT}/Update/${advertId}`, advert);
  }

  deleteAdvert(id : number) : Observable<any>{
    return  this.http.delete(`${URL_ADVERT}/${id}`);
  }





}
