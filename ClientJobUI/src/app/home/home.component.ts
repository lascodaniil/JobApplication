import {Component, OnInit} from '@angular/core';
import {Observable} from 'rxjs';
import {FormControl} from '@angular/forms';
import {map, startWith} from 'rxjs/operators';
import {JobType} from '../_models/JobType';
import {JobService} from '../_services/job.service';
import {MatDialog, MatDialogRef} from '@angular/material/dialog';
import {ViewJobComponent} from './view-job/view-job.component';
import {JobForViewDTO} from "../_models/DTO/JobForViewDTO";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  searchControl = new FormControl();
  jobTypes: JobType[];
  dialogRef: MatDialogRef<any>;
  filteredOptions: Observable<JobForViewDTO[]>;
  AllJobs: JobForViewDTO[];


  constructor(private jobService: JobService,
              public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.jobService.getAllJobs().subscribe(data => {
      this.AllJobs = data;
      this.filteredOptions = this.searchControl.valueChanges
        .pipe(
          startWith(''),
          map(searchText => {
            return searchText ? this._filter(searchText) : this.AllJobs.slice();
          })
        );
    });

    this.jobService.getJobsTypes().subscribe(data => {
      this.jobTypes = data;
    });
  }

  onViewJob(jobId) {
    this.dialogRef = this.dialog.open(ViewJobComponent, {
      data: {
        id: jobId
      }
    });
  }

  private _filter(value: string): JobForViewDTO[] {
    this.jobService.getAllJobs().subscribe(data => {
      this.AllJobs = data;
    });
    const filterValue = value.toLowerCase();
    return this.AllJobs.filter(job => job.title.toLowerCase().indexOf(filterValue) === 0);
  }
}
