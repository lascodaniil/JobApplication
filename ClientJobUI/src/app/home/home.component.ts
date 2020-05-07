import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs';
import {FormControl} from '@angular/forms';
import {map, startWith} from 'rxjs/operators';
import {JobType} from '../_models/JobType';
import {JobService} from '../_services/job.service';
import {JobDTO} from '../_models/DTO/JobDTO';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  searchControl = new FormControl();
  jobTypes : JobType[];
  filteredOptions : Observable<JobDTO[]>;
  AllJobs : JobDTO[];


  constructor(private jobService : JobService) {
  }

  ngOnInit(): void {
    this.jobService.getAllJobs().subscribe(data =>{this.AllJobs = data ; this.filteredOptions = this.searchControl.valueChanges
      .pipe(
        startWith(''),
        map(job => job ? this._filter(job.title): this.AllJobs.slice()));



    });
    this.jobService.getJobsTypes().subscribe(data =>{this.jobTypes = data});

  }

  private _filter(value: string): JobDTO[] {

    this.jobService.getAllJobs().subscribe(data =>{this.AllJobs = data });
    const filterValue = value.toLowerCase();
    return this.AllJobs.filter(job => job.title.toLowerCase().indexOf(filterValue)===0);
  }


}
