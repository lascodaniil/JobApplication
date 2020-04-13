import { Component, OnInit } from '@angular/core';
import { Job } from './job.model';
import { JobService } from '../services/job.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.css']
})

export class JobComponent implements OnInit {
  public allJobs : Job[];
  public JobId : Job;
  public Id: number;
  constructor( private jobService : JobService, router:Router, activateRoute:ActivatedRoute ) { 
      this.Id = Number.parseInt(activateRoute.snapshot.params["id"]);
  }

  ngOnInit(){
    this.jobService.getAllJobs()
    .subscribe(data => {this.allJobs = data; console.log(this.allJobs);});
  }
  
  getById(){
    this.jobService.getJobById(this.Id).subscribe(x=>{this.JobId=x; console.log(x)});
  }
}

