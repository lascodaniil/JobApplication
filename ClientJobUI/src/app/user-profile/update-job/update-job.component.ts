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
  imageFile:any;
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
// debugger
    console.log(this.job.base64Photo);
    this.job.base64Photo = this.imageFile !=undefined?this.imageFile : '';
    this.jobService.addjob(this.job).subscribe(() => {
      this.dialogRef.close();
    });
  }

  handelFileInput(event:any){
    if (event.target.files) {
      const filesAmount = event.target.files.length;
      for (let i = 0; i < filesAmount; i++) {
          const reader = new FileReader();
          reader.onload = (event: any) => {
            this.imageFile = event.target.result;
          };
          reader.readAsDataURL(event.target.files[i]);
      }
    }

  }

  onJobEdit(job, id) {
    console.log(job, id);
    console.log(this.imagePath);
    this.jobService.editJob(job, id).subscribe(() => {
      this.dialogRef.close();
    });
  }


}
