import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ChatService } from '../_services/chat.service';
import { ChatDTO } from '../_models/DTO/ChatDTO';
import { JobDTO } from '../_models/DTO/JobDTO';
import { ProfileDTO } from '../_models/DTO/ProfileDTO';
import { ProfileServiceService } from '../_services/profile-service.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-chat-box',
  templateUrl: './chat-box.component.html',
  styleUrls: ['./chat-box.component.css']
})
export class ChatBoxComponent implements OnInit {
  isClosed: boolean = true;
  chat: ChatDTO;
  chats: Array<ChatDTO> = [];
  employerId: number;
  employer: string;
  student: string;
  jobTitle: string;
  inputValue;
  loggedUser = {} as ProfileDTO;
  userRole: string;
  chatName: string;
  onlineUsers: string[] = [];
  isOnline: boolean = false;
  isLoggedIn: boolean = false;
  constructor(private formBuilder: FormBuilder, private chatService: ChatService,
              private profileService: ProfileServiceService, private authService: AuthService) {
    this.inputValue = this.formBuilder.group({
      text: ''
    });

  }

  ngOnInit(): void {
    this.setLoggedUser();

    this.chatService.messageReceived.subscribe((data: ChatDTO) => {
      if (this.userRole === 'Employer') {
        if (this.loggedUser.fullName === data.employer) {
          if(this.jobTitle !== data.jobTitle){
            this.chats = [];
          }
          this.chats.push(data);
          this.employer = data.employer;
          this.jobTitle = data.jobTitle;
          this.student = data.student;
          this.isClosed = false;
          this.chatName = data.student;
        }
      } else {
        if (this.loggedUser.fullName === data.student) {
          if(this.jobTitle !== data.jobTitle){
            this.chats = [];
          }
          this.chats.push(data);
          this.employer = data.employer;
          this.jobTitle = data.jobTitle;
          this.student = data.student;
          this.isClosed = false;
          this.chatName = data.employer;

        }
      }
      this.isOnline = this.onlineUsers.includes(this.chatName);



    });

    this.chatService.onlineUsers.subscribe((data: string[]) => {
      this.onlineUsers = data;

      this.isOnline = this.onlineUsers.includes(this.chatName);
      this.jobTitle = this.authService.isLoggedIn() ? this.jobTitle : undefined;
      this.isLoggedIn = this.authService.isLoggedIn();
      if (this.authService.isLoggedIn()) {
        const decoded = this.authService.parseToken(this.authService.getToken());
        this.userRole = decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
        this.profileService.getProfileUser().subscribe(
          user => {
            this.loggedUser = user;
          });
      }
    });

    this.chatService.chatReceived.subscribe((data: JobDTO) => {
      this.isLoggedIn = this.authService.isLoggedIn();
      this.chats = [];
      this.employer = data.employer;
      this.jobTitle = data.title;
      this.student = this.loggedUser.fullName;
      this.isClosed = false;
      this.chatName = data.employer;
      this.isOnline = this.onlineUsers.includes(this.chatName);
      this.profileService.getProfileUser().subscribe(
        user => {
          this.loggedUser = user;
        });
    });

  }

  setLoggedUser() {
    this.profileService.getProfileUser().subscribe(
      user => {
        this.loggedUser = user;
        this.isLoggedIn = this.authService.isLoggedIn();
        this.chatService.initSignalR();
      });
  }

  toggle() {
    this.isClosed = !this.isClosed;
  }

  onSend(value) {

    this.chat = {
      date: new Date(),
      employer: this.userRole === 'Employer' ? this.loggedUser.fullName : this.employer,
      from: this.loggedUser.fullName,
      jobTitle: this.jobTitle,
      message: value.text,
      student: this.userRole === 'Student' ? this.loggedUser.fullName : this.student
    }
    this.chatService.sendMessage(this.chat);
    this.inputValue.reset();

  }

  onClose(){
    this.jobTitle = null;
  }
}
