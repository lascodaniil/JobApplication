import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const URL ="http://localhost:5000/Auth/login";

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

export class TokenParam{
  public accessToken:string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public tokenObject : string="";
  constructor(private http:HttpClient) { }
    
  login(username:string, password:string): Observable<TokenParam>{
      return this.http.post<TokenParam>(URL,{Username : username, Password:password}, httpOptions);
    }

  public getToken(): string {
      return localStorage.getItem('accessToken');
     
    }

   public isLoggedIn():boolean{
      return this.getToken()? true : false;
    }
  
    public logout():boolean{
      localStorage.removeItem('accessToken');
      return true;
    }
}