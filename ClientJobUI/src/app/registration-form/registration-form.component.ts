import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder} from '@angular/forms';
import { NgForm } from "@angular/forms";
import { RegisterUserModel } from '../Interfaces/RegisterUserModel';
import { AuthService } from '../services/auth.service';




@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements OnInit {

  roles: string[]=["Employer","Student"]; 
  
  constructor(private authService  :AuthService) { }
  SelectedRole : string;
  registeredUser = new RegisterUserModel();
  token: string;
  onSubmit(form){
      console.log(this.registeredUser);
      this.register();
  }

  ngOnInit(): void {
    
  }

  register(){
     this.authService.registration(this.registeredUser)
     .subscribe(x=>{this.token=x.accessToken;this.authService.tokenObject=this.token; console.log(this.token);localStorage.setItem('accessToken', this.authService.tokenObject)}); 
  }
}
