import { Component, OnInit,Inject } from '@angular/core';
import {FormGroup, FormControl, FormBuilder, Validator, FormsModule, Validators} from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';



const URL ="http://localhost:5000/Auth/login";
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};


@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {

  form:FormGroup;
  token: string;
  constructor(private activatedRoute : ActivatedRoute,
    private router: Router,
    private http: HttpClient, private builder:FormBuilder, private authService : AuthService) {
       
    }

  ngOnInit(): void {
    this.form =this.builder.group ({
        userName: ['',[Validators.required]],
        passWord:['',Validators.required]
    });
  }

  login() : void {
    this.authService.login(this.form.value.userName, this.form.value.passWord)
    .subscribe(x=>{this.token=x.accessToken; this.authService.tokenObject = this.token; console.log(this.authService.tokenObject); localStorage.setItem('accessToken', this.authService.tokenObject) }) 
      
  }

  

}
