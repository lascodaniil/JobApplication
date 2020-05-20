import {Component, Inject, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import {JobService} from '../../_services/job.service';
import {JobForTableDTO} from "../../_models/DTO/JobForTableDTO";

@Component({
  selector: 'app-view-job',
  templateUrl: './view-job.component.html',
  styleUrls: ['./view-job.component.css']
})
export class ViewJobComponent implements OnInit {
  job: JobForTableDTO;

  constructor(@Inject(MAT_DIALOG_DATA) public jobData: {id: number},
              private jobService: JobService) { }

  ngOnInit(): void {
    this.jobService.getJobById(this.jobData.id).subscribe((job:JobForTableDTO)=> {
      this.job = job;
    });
  }

}
