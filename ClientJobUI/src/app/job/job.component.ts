import {Component, OnInit} from '@angular/core';
import {JobService} from '../_services/job.service';
import {AuthService} from '../_services/auth.service';
import {ToolBarService} from '../_services/toolbar.service.service';
import {JobDTO} from '../_models/DTO/JobDTO';
import {PaginatedRequest} from '../_models/PaginatedRequest';


@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.css']
})

export class JobComponent implements OnInit {
  pageOptions = [1, 2, 3, 4, 5];
  filter = {} as PaginatedRequest;
  allJobs: JobDTO[];


  constructor(private jobService: JobService,
              public authService: AuthService,
              private toolBarService: ToolBarService) {
  }

  ngOnInit() {
    this.toolBarService.setTitle('Jobs');
    this.filter.pageSize = 100;
    this.loadJobs();
  }

  onFiltered(filter: PaginatedRequest) {
    this.filter = Object.assign(this.filter, filter);
    this.loadJobs();
  }

  loadJobs() {
    this.jobService.getAllJobPaginated(this.filter).subscribe(data => {
      this.allJobs = data.items;
      console.log(this.allJobs);
    });
  }
}

