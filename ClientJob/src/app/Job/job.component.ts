import { Component, OnInit } from '@angular/core';
import { RepositoryService } from '../services/repository.service';
import { Job } from './job.model';

@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.css']
})

export class JobComponent {
  public allJobs : Job[];
  constructor( public repository : RepositoryService ) { }
  
  ngOnInit(): void {
    this.repository.getJobs().subscribe(
      res=>{this.allJobs=res}
    );
  }
}
