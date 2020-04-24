import { Component, OnInit } from '@angular/core';
import { RegisterUserModel } from '../Interfaces/RegisterUserModel';
import { LoginUserModel } from '../Interfaces/LoginUserModel';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  loggedUser = new LoginUserModel();
   formGroup : FormGroup
   token:string;

   constructor(private activatedRouter: ActivatedRoute,
    private http: HttpClient,private formBuilder: FormBuilder, private auth: AuthService){
      this.createForm();

    }
    createForm(){
      this.formGroup = this.formBuilder.group({
        userName: ['',[Validators.required, Validators.pattern("^[a-z0-9_\-]+$")]],
        passWord:['',Validators.required]
      })
    }

   onSubmit(){
    this.auth.login(this.formGroup.value.userName, this.formGroup.value.passWord)
     .subscribe(x=>{this.token=x.accessToken; this.auth.tokenObject = this.token;console.log(this.token) ; localStorage.setItem('accessToken', this.auth.tokenObject) }) 
  }
  
  ngOnInit(): void {
    
  }

}
