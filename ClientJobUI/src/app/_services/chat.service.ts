import { Injectable, EventEmitter } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { ChatDTO } from '../_models/DTO/ChatDTO';
import { JobDTO } from '../_models/DTO/JobDTO';
import {JobForTableDTO} from "../_models/DTO/JobForTableDTO";
@Injectable({
  providedIn: 'root'
})
export class ChatService {
  messageReceived = new EventEmitter<ChatDTO>();
  chatReceived = new EventEmitter<JobForTableDTO>();
  connectionEstablished = new EventEmitter<Boolean>();
  onlineUsers = new EventEmitter<string[]>();
  private connectionIsEstablished = false;
  private _hubConnection: HubConnection;

  private url = 'http://localhost:5000/';

  constructor() {
    this.createConnection();
    this.registerOnServerEvents();
    this.startConnection();
  }

  initSignalR() {
    if (!this.connectionEstablished) {
      this.createConnection();
      this.registerOnServerEvents();
      this.startConnection();
    }

  }

  sendMessage(message: ChatDTO) {
    console.log(message);
    this._hubConnection.invoke('PrivateSendMessage', message.jobTitle, message.employer, message.student, message.from, message.message);
  }

  private createConnection() {
    this._hubConnection = new HubConnectionBuilder()
      .withUrl(this.url + 'chat')
      .build();
  }

  private startConnection(): void {
    const self = this;
    this._hubConnection
      .start()
      .then(() => {
        this.connectionIsEstablished = true;
        console.log('Hub connection started');
        this.connectionEstablished.emit(true);
        if (localStorage.getItem('accessToken')) {
          this._hubConnection.invoke('NewOnlineUser', localStorage.getItem('accessToken'));
        }
      })
      .catch(err => {
        setTimeout(function () { self.startConnection(); }, 5000);
      });
  }

  private registerOnServerEvents(): void {
    this._hubConnection.on('sendToAll', (data: ChatDTO) => {
      this.messageReceived.emit(data);
    });

    this._hubConnection.on('OnlineUsers', (data: string[]) => {
      this.onlineUsers.emit(data);
    })

  }

  newChat(job: JobForTableDTO) {
    this.chatReceived.emit(job);
  }

  addOnlineUser() {
    this._hubConnection.invoke('NewOnlineUser', localStorage.getItem('accessToken'));
  }
  removeOnlineUser() {
    this._hubConnection.invoke('LogoutUser', localStorage.getItem('accessToken'));
  }

}
