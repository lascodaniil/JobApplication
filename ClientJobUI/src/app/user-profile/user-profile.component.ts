import {Component, OnInit} from '@angular/core';
import {JobService} from '../services/job.service';
import {PaginatedRequest} from '../model/PaginatedRequest';
import {JobRowRequest} from '../model/JobRowRequest';
import {ToolBarService} from '../services/toolbar.service.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})

export class UserProfileComponent implements OnInit {
  displayedColumns: string[] = ['id', 'title', 'category', 'employer', 'actions'];
  filter = {} as PaginatedRequest;
  employerJobs = [] as JobRowRequest[];

  constructor(private jobService: JobService,
              private toolBarService: ToolBarService) {
  }

  ngOnInit() {
    this.toolBarService.setTitle('Profile');
    this.filter.pageSize = 5;
    this.jobService.getAllJobPaginated(this.filter).subscribe(data => {
      this.employerJobs = data.items;
    });
  }
}
