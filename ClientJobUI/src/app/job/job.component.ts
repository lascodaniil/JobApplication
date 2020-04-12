import { Component, OnInit } from '@angular/core';
import { Job } from './job.model';
import { JobService } from '../services/job.service';

@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.css']
})

export class JobComponent {
  public allJobs : Job[];
  public JobId : Job;
  constructor( private jobService : JobService ) { }
  


  ngOnInit(){
    this.jobService.getAllJobs()
    .subscribe(data => {this.allJobs = data});


  }
}

