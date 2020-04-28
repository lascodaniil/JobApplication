import {Component} from '@angular/core';
import {FormGroup, Validators} from '@angular/forms';
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
  userName: string;
  password: string;
  token: string;

  constructor(private activatedRouter: ActivatedRoute,
              private router: Router,
              private toolBarService: ToolBarService,
              private http: HttpClient, private auth: AuthService) {
    this.toolBarService.setTitle('Login');
  }

  onSubmit() {
    this.auth.login(this.userName, this.password)
      .subscribe(data => {
        this.token = data.accessToken;
        this.auth.tokenObject = this.token;
        localStorage.setItem('accessToken', this.auth.tokenObject);
        this.router.navigate(['/profile']);
      });
  }
}
