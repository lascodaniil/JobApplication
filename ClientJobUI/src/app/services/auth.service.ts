import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import {RegisterUserModel} from '../Interfaces/RegisterUserModel';
import {Router} from '@angular/router';

const URL_LOG = 'http://localhost:5000/Auth/Login';
const URL_REGISTER = 'http://localhost:5000/Auth/Registration';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};

export class AuthServiceResponse {
  public accessToken: string;
}

export class UserCredentials {
   public  email: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public tokenObject: string = '';

  constructor(private http: HttpClient, private router: Router) {
  }

  login(username: string, password: string): Observable<AuthServiceResponse> {
    return this.http.post<AuthServiceResponse>(URL_LOG, {Username: username, Password: password}, httpOptions);
  }

  registration(register: RegisterUserModel) {
    return this.http.post<AuthServiceResponse>(URL_REGISTER, register, httpOptions);
  }

  public getToken(): string {
    return localStorage.getItem('accessToken');
  }

  public isLoggedIn(): boolean {
    return !!this.getToken();
  }

  public logout(): boolean {
    localStorage.removeItem('accessToken');
    this.router.navigate(['/sign-in']);
    return true;
  }
}
