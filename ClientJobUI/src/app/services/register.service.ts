import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { registerLocaleData } from '@angular/common';
import { Observable } from 'rxjs';

const URL ="http://localhost:5000/Auth/Register";

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

export class TokenParam{
  public accessToken:string;
}

@Injectable({
  providedIn: 'root'
})
export class RegisterService {
  public tokenObject : string="";
  constructor(private http:HttpClient) {
  }

  registerUser(Username:string, Password:string, Email:string, DisplayName:string ) : Observable<TokenParam>{
      return this.http.post<TokenParam>(URL,{Username:Username, Password:Password, Email:Email, DisplayName:DisplayName}, httpOptions);  
    }
}


