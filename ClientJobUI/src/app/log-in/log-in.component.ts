import { Component, OnInit,Inject } from '@angular/core';
import {FormGroup, FormControl, FormBuilder, Validator, FormsModule, Validators} from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';



@Component({
  selector: 'app-log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {

  form:FormGroup;
  constructor(private activatedRoute : ActivatedRoute,
    private router: Router,
    private http: HttpClient, private builder:FormBuilder) {
       
    }

 

  ngOnInit(): void {
    this.form =this.builder.group ({
        userName: ['',[Validators.required]],
        passWord:['',Validators.required]
    });
  }


  login() {
    console.log(this.form.value.userName);
    
    // this.username = this.form.value.userName;
    // this.password = this.form.value.passWord;
    // console.log(this.username);
    // console.log(this.password);
  }
 

}
