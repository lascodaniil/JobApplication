import {Component, EventEmitter, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogRef,} from '@angular/material/dialog';
import {JobService} from '../../services/job.service';
import {Category} from '../../model/Category';
import {AddJobData} from '../../model/AddJobData';
import {JobForPostDTO} from '../../model/JobForPostDTO';
import {City} from '../../model/City';


@Component({
  selector: 'app-add-job',
  templateUrl: 'add-job.component.html',
  styleUrls: ['add-job.component.css'],
})
export class AddJobComponent implements OnInit {
  categories: Category[];
  cities: City[];
  newJob = {} as JobForPostDTO;

  constructor(@Inject(MAT_DIALOG_DATA)
              private jobData: AddJobData,
              private jobService: JobService,
              public dialogRef: MatDialogRef<AddJobComponent>) {
  }

  ngOnInit(): void {
    this.categories = this.jobData.categories;
    this.cities = this.jobData.cities;
  }

  onJobAdd() {
    this.jobService.addNewJob(this.newJob).subscribe(() => {
      this.dialogRef.close();
    });
  }
}
