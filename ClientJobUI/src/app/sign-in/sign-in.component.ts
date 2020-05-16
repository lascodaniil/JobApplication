import {Component} from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {HttpClient} from '@angular/common/http';
import {AuthService} from '../_services/auth.service';
import {ToolBarService} from '../_services/toolbar.service.service';
import decode from 'jwt-decode';
import { ChatService } from '../_services/chat.service';

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
              private http: HttpClient, private auth: AuthService, private chatService: ChatService
  ) {
    this.toolBarService.setTitle('Login');
  }

  onSubmit() {
    this.auth.login(this.userName, this.password)
      .subscribe(data => {
        this.token = data.accessToken;
        this.auth.tokenObject = this.token;
        localStorage.setItem('accessToken', this.auth.tokenObject);
        this.auth.setUserRole();
        this.chatService.addOnlineUser(); // SignalR chat
        this.router.navigate(['/profile']);
      });
  }
}
