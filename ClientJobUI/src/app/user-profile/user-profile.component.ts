import {Component, OnInit} from '@angular/core';
import {JobService} from '../services/job.service';
import {PaginatedRequest} from '../model/PaginatedRequest';
import {ToolBarService} from '../services/toolbar.service.service';
import {UpdateJobComponent} from './update-job/update-job.component';
import {MatDialog, MatDialogRef} from '@angular/material/dialog';
import {JobRowRequest} from '../model/JobRowRequest';
import {Category} from '../model/Category';
import {City} from '../model/City';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})

export class UserProfileComponent implements OnInit {
  displayedColumns: string[] = ['Id', 'Title', 'Category', 'Contact', 'Actions'];
  filter = {} as PaginatedRequest;
  dialogRef: MatDialogRef<any>;
  jobsCategories = [] as Category[];
  jobsCities = [] as City[];
  employerJobs = [] as JobRowRequest[];

  paginationOptions = {
    pageSizeOptions: [25, 50, 100, 250],
    pageSize: 25,
    pageIndex: 1
  };

  constructor(private jobService: JobService,
              private toolBarService: ToolBarService,
              public dialog: MatDialog) {
  }

  ngOnInit() {
    this.filter.pageSize = this.paginationOptions.pageSize;
    this.toolBarService.setTitle('Profile');
    this.loadUserJobs();
    this.jobService.getCategories().subscribe(data => {
      this.jobsCategories = data;
    });
    this.jobService.getCity().subscribe(data => {
      this.jobsCities = data;
    });
  }

  loadUserJobs() {
    this.jobService.getAllJobPaginatedUser(this.filter).subscribe(data => {
      this.employerJobs = data.items;
    });
  }

  onPaginatorChange(pagination) {
    this.filter = {
      ...this.filter,
      pageSize: pagination.pageSize,
      pageIndex: pagination.pageIndex
    };
    this.loadUserJobs();
  }

  onUpdate(id?: number) {
    this.dialogRef = this.dialog.open(UpdateJobComponent, {
      data: {
        categories: this.jobsCategories,
        cities: this.jobsCities,
        id: id ? id : null
      }
    });

    this.dialogRef.afterClosed().subscribe(() => {
      this.loadUserJobs();
    });
  }

  onDelete(id: number){
       this.jobService.deleteJob(id).subscribe(() => {
         this.loadUserJobs(); console.log('stergere'); });
  }
}
