import {Component, OnInit} from '@angular/core';
import {JobService} from '../services/job.service';
import {AuthService} from '../services/auth.service';
import {ToolBarService} from '../services/toolbar.service.service';
import {JobDTO} from '../models/JobDTO';
import {PaginatedRequest} from '../models/PaginatedRequest';


@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.css']
})

export class JobComponent implements OnInit {
  pageOptions = [1, 2, 3, 4, 5];
  filter = {} as PaginatedRequest;
  actions = false;
  allJobs: JobDTO[];

  constructor(private jobService: JobService,
              private authService: AuthService,
              private toolBarService: ToolBarService) {
  }

  ngOnInit() {
    this.toolBarService.setTitle('Jobs');
    this.filter.pageSize = this.pageOptions[4];
    this.actions = this.authService.isLoggedIn();
    this.loadJobs();
  }

  onFiltered(filter: PaginatedRequest) {
    this.filter = Object.assign(this.filter, filter);
    this.loadJobs();
  }

  loadJobs() {
    this.jobService.getAllJobPaginated(this.filter).subscribe(data => {
      this.allJobs = data.items; console.log(this.allJobs);
    });
  }
}

