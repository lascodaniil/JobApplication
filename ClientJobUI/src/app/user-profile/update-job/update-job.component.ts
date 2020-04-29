import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef,} from '@angular/material/dialog';
import {JobService} from '../../services/job.service';
import {Category} from '../../models/Category';
import {City} from '../../models/City';
import {JobDTO} from '../../models/JobDTO';
import {AddJobData} from '../../models/AddJobData';


@Component({
  selector: 'app-add-job',
  templateUrl: 'update-job.component.html',
  styleUrls: ['update-job.component.css'],
})
export class UpdateJobComponent implements OnInit {
  categories: Category[];
  cities: City[];
  job = {} as JobDTO;
  imagePath : string;
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

    console.log(this.imagePath);
    let a = this.imagePath.split('fakepath\\');
    console.log(a[0]);
    this.jobService.addjob(this.job).subscribe(() => {
      this.dialogRef.close();
    });
  }

  onJobEdit(job, id) {
    console.log(job, id);
    console.log(this.imagePath);
    this.jobService.editJob(job, id).subscribe(() => {
      this.dialogRef.close();
    });
  }


}
