import { Component, OnInit } from '@angular/core';
import {ToolBarService} from '../_services/toolbar.service.service';
import {ProfileServiceService} from '../_services/profile-service.service';
import {ProfileDTO} from '../_models/DTO/ProfileDTO';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.css']
})
export class EditProfileComponent implements OnInit {

  loggedUser = {} as ProfileDTO;
  uploadFileName: string;
  profileImage: File = null;

  constructor(private toolBarService : ToolBarService,
              private profileService: ProfileServiceService) {
  }

  ngOnInit(): void {
    this.toolBarService.setTitle("Edit Profile");
    this.profileService.getProfileUser().subscribe((data) => {this.loggedUser = data; console.log(this.loggedUser)});

  }

  onUploadImage(file) {
      this.profileImage = <File>file.target.files[0];
      this.uploadFileName = file.target.files[0].type.indexOf("image") !== -1 ? file.target.files[0].name : '';
  }


  onUpdateProfile(loggedUser, id){
    let formData: FormData = new FormData();
    formData.append('Image', this.profileImage);
    formData.append("FirstName", this.loggedUser.firstName);
    formData.append("LastName", this.loggedUser.lastName);
    formData.append("PhoneNumber", this.loggedUser.phoneNumber);
    this.profileService.updateProfileUser(formData).subscribe();
  }
}
