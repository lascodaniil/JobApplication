import {AfterContentInit, Component, OnInit} from '@angular/core';
import {LoginUserModel} from '../Interfaces/LoginUserModel';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {AuthService} from '../services/auth.service';
import {ToolBarService} from '../services/toolbar.service.service';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent {
  formGroup: FormGroup;
  token: string;

  constructor(private activatedRouter: ActivatedRoute,
              private router: Router,
              private toolBarService: ToolBarService,
              private http: HttpClient, private formBuilder: FormBuilder, private auth: AuthService) {
    this.toolBarService.setTitle('Login');
    this.createForm();
  }

  createForm() {
    this.formGroup = this.formBuilder.group({
      userName: ['', Validators.required],
      passWord: ['', Validators.required]
    });
  }

  onSubmit() {
    this.auth.login(this.formGroup.value.userName, this.formGroup.value.passWord)
      .subscribe(data => {
        this.token = data.accessToken;
        this.auth.tokenObject = this.token;
        localStorage.setItem('accessToken', this.auth.tokenObject);
        this.router.navigate(['/profile']);
      });
  }
}
