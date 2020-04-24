import { Component, OnInit } from '@angular/core';
import { JobService } from '../services/job.service';
import { FormControl } from '@angular/forms';
import { PaginatedRequest } from '../model/PaginatedRequest';
import { Job } from '../model/Job';


@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.css']
})

export class JobComponent implements OnInit {
  pageOptions = [5, 10, 25, 100];
  filter = {} as PaginatedRequest;
  allJobs: Job[];
  lenght : number;

  sortedData: Job[] = this.allJobs;
  searchInput : FormControl;
  constructor(private jobService: JobService) { }

  ngOnInit() {
    this.filter.pageSize = this.pageOptions[1];
    this.loadJobs();
  }

  onFiltered( filter : PaginatedRequest) {
    this.filter = Object.assign(this.filter, filter);
    this.loadJobs();
  }

  loadJobs() {
    this.jobService.getAllJobs(this.filter).subscribe( data => { 
      this.allJobs = data.items;
    });
  }
}

