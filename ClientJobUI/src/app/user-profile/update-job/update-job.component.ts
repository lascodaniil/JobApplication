import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef,} from '@angular/material/dialog';
import {JobService} from '../../_services/job.service';
import {JobDTO} from '../../_models/DTO/JobDTO';
import {AddJobData} from '../../_models/AddJobData';
import {MatDatepickerInputEvent} from '@angular/material/datepicker';
import {JobForViewDTO} from "../../_models/DTO/JobForViewDTO";
import {JobForTableDTO} from "../../_models/DTO/JobForTableDTO";


@Component({
  selector: 'app-update-job',
  templateUrl: 'update-job.component.html',
  styleUrls: ['update-job.component.css'],
})
export class UpdateJobComponent implements OnInit {
  job = {} as JobForTableDTO;
  uploadFileName: string;
  profileImage: File = null;

  constructor(
    private jobService: JobService,
    @Inject(MAT_DIALOG_DATA) public jobData: AddJobData,
    public dialogRef: MatDialogRef<UpdateJobComponent>){
  }

  ngOnInit(): void {
    if (this.jobData.id) {
      this.jobService.getJobById(this.jobData.id).subscribe((job: JobForTableDTO) => {
        this.job = job;
        this.job.imagePath = '';
      });
    }
  }

  onJobAdd() {
    let formData: FormData = new FormData();
    formData.append('Image', this.profileImage);
    formData.append('CategoryId', `${this.job.categoryId}`);
    formData.append('title', this.job.title);
    formData.append('CityId', `${this.job.cityId}`);
    formData.append('salary', `${this.job.salary}`);
    formData.append('contact', `${this.job.contact}`);
    formData.append('finishedOn',(new Date(this.job.finishedOn)).toUTCString());
    formData.append("TypeJobId", `${this.job.typeJobId}`);

      this.jobService.AddJobFormData(formData).subscribe(() => {
      this.dialogRef.close();
    });

  }

  onJobEdit(job, id) {
    let formData: FormData = new FormData();
    formData.append('Image', this.profileImage);
    formData.append('CategoryId', `${this.job.categoryId}`);
    formData.append('title', this.job.title);
    formData.append('CityId', `${this.job.cityId}`);
    formData.append('salary', `${this.job.salary}`);
    formData.append('contact', `${this.job.contact}`);
    formData.append('finishedOn',(new Date(this.job.finishedOn)).toUTCString());
    formData.append("TypeJobId", `${this.job.typeJobId}`);
    this.jobService.editJob(formData, id).subscribe(() => {
       this.dialogRef.close();
     });
  }

  onUploadImage(file) {
    this.profileImage = <File>file.target.files[0];
    this.uploadFileName = file.target.files[0].type.indexOf("image") !== -1 ? file.target.files[0].name : '';
  }

  addEvent(event: MatDatepickerInputEvent<any>){
    this.job.finishedOn= event.value;
  }
}
