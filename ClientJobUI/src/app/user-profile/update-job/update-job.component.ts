import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef,} from '@angular/material/dialog';
import {JobService} from '../../_services/job.service';
import {CategoryDTO} from '../../_models/DTO/CategoryDTO';
import {CityDTO} from '../../_models/DTO/CityDTO';
import {JobDTO} from '../../_models/DTO/JobDTO';
import {AddJobData} from '../../_models/AddJobData';
import {MatDatepicker, MatDatepickerInput, MatDatepickerInputEvent} from '@angular/material/datepicker';


@Component({
  selector: 'app-add-job',
  templateUrl: 'update-job.component.html',
  styleUrls: ['update-job.component.css'],
})
export class UpdateJobComponent implements OnInit {
  categories: CategoryDTO[];
  cities: CityDTO[];
  job = {} as JobDTO;
  uploadFileName: string;
  constructor(
    private jobService: JobService,
    @Inject(MAT_DIALOG_DATA) public jobData: AddJobData,
    public dialogRef: MatDialogRef<UpdateJobComponent>) {
  }

  ngOnInit(): void {
    this.categories = this.jobData.categories;
    this.cities = this.jobData.cities;
    if (this.jobData.id) {
      this.jobService.getJobById(this.jobData.id).subscribe((job: JobDTO) => {
        this.job = job;
      });
    }
  }

  onJobAdd() {
    this.jobService.addjob(this.job).subscribe(() => {
      this.dialogRef.close();
    });
  }

  onJobEdit(job, id) {
    console.log(this.job.finishedOn);
    this.jobService.editJob(job, id).subscribe(() => {
      this.dialogRef.close();
    });
  }

  onUploadImage(file) {
    this.uploadFileName = file.target.files[0].type.indexOf("image") !== -1 ? file.target.files[0].name : '';
  }

  addEvent(event: MatDatepickerInputEvent<any>){
    this.job.finishedOn= event.value;
  }
}
