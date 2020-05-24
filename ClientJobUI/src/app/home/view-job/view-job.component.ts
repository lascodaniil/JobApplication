import {Component, Inject, OnDestroy, OnInit} from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog';
import {JobService} from '../../_services/job.service';
import {JobForTableDTO} from "../../_models/DTO/JobForTableDTO";
import {ChatService} from "../../_services/chat.service";
import {Subscription} from "rxjs";

@Component({
  selector: 'app-view-job',
  templateUrl: './view-job.component.html',
  styleUrls: ['./view-job.component.css']
})
export class ViewJobComponent implements OnInit, OnDestroy {
  job = {} as JobForTableDTO;
  jobsSubscription;
  routeParamsSubscription : Subscription;
  enrollJobSubscription: Subscription;
  jobsByTypeSubscription: Subscription;

  constructor(@Inject(MAT_DIALOG_DATA) public jobData: { id: number },
              private jobService: JobService, private chatService: ChatService) {
  }

  ngOnInit(): void {
    this.jobService.getJobById(this.jobData.id).subscribe((job: JobForTableDTO) => {
      this.job = job;
    });
  }


  onEnroll(jobId: number) {
    this.enrollJobSubscription = this.jobService.addJobStudent(jobId).subscribe();
  }

  onChat(job: JobForTableDTO) {
    this.chatService.newChat(job);
  }

  ngOnDestroy(): void {
    this.jobsByTypeSubscription && this.jobsByTypeSubscription.unsubscribe();
    this.jobsSubscription && this.jobsSubscription.unsubscribe();
    this.enrollJobSubscription && this.enrollJobSubscription.unsubscribe();
    this.routeParamsSubscription.unsubscribe();
  }
}
