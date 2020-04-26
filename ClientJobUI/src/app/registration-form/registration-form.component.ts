import {Component, OnInit} from '@angular/core';
import {FormGroup, FormBuilder} from '@angular/forms';
import {NgForm} from '@angular/forms';
import {RegisterUserModel} from '../Interfaces/RegisterUserModel';
import {AuthService} from '../services/auth.service';
import {ToolBarService} from '../services/toolbar.service.service';
import {Router} from '@angular/router';


@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent implements OnInit {

  roles: string[] = ['Employer', 'Student'];

  constructor(private authService: AuthService,
              private router: Router,
              private toolBarService: ToolBarService) {
  }

  SelectedRole: string;
  registeredUser = new RegisterUserModel();
  token: string;

  onSubmit(form) {
    this.register();
  }

  ngOnInit(): void {
    this.toolBarService.setTitle('Register');
  }

  register() {
    this.authService.registration(this.registeredUser)
      .subscribe(data => {
        this.token = data.accessToken;
        this.authService.tokenObject = this.token;
        localStorage.setItem('accessToken', this.authService.tokenObject);
        this.router.navigate(['/profile']);
      });
  }
}
