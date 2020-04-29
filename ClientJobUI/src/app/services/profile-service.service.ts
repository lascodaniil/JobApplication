import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';
import {AuthService, AuthServiceResponse} from './auth.service';
import {Observable} from 'rxjs';
import {getToken} from 'codelyzer/angular/styles/cssLexer';
import {EmployerProfileDTO} from '../models/EmployerProfileDTO';


const URL_PROFILE ="http://localhost:5000/User/";

@Injectable({
  providedIn: 'root'
})
export class ProfileServiceService {
  constructor(private http: HttpClient) {
  }

  getProfileUser(): Observable<EmployerProfileDTO> {
      return this.http.get<EmployerProfileDTO>(`${URL_PROFILE}/EmployerProfile`);
  }
}
