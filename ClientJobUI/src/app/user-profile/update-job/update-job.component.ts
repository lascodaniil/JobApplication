import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef,} from '@angular/material/dialog';
import {JobService} from '../../services/job.service';
import {Category} from '../../model/Category';
import {AddJobData} from '../../model/AddJobData';
import {JobForPostDTO} from '../../model/JobForPostDTO';
import {City} from '../../model/City';


@Component({
  selector: 'app-add-job',
  templateUrl: 'update-job.component.html',
  styleUrls: ['update-job.component.css'],
})
export class UpdateJobComponent implements OnInit {
  categories: Category[];
  cities: City[];
  job = {} as JobForPostDTO;

  constructor(
    private jobService: JobService,
    @Inject(MAT_DIALOG_DATA) public jobData: AddJobData,
    public dialogRef: MatDialogRef<UpdateJobComponent>) {
  }

  ngOnInit(): void {
    this.categories = this.jobData.categories;
    this.cities = this.jobData.cities;
    if (this.jobData.id) {
      this.jobService.getJobById(this.jobData.id).subscribe((job: JobForPostDTO) => {
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
    console.log(job, id);
    this.jobService.editJob(job, id).subscribe(() => {
      this.dialogRef.close();
    });
  }
}
