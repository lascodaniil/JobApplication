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
  constructor( public jobService : JobService ) { }
  
  ngOnInit(): void {
    this.jobService.getAllJobs().subscribe(
      res=>{this.allJobs=res}
    );
  }
}

