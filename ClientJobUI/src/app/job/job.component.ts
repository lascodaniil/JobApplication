import {Component, OnDestroy, OnInit} from '@angular/core';
import {JobService} from '../_services/job.service';
import {ToolBarService} from '../_services/toolbar.service.service';
import {PaginatedRequest} from '../_models/PaginatedRequest';
import {ActivatedRoute, Params} from '@angular/router';
import {ChatService} from '../_services/chat.service';
import {JobForTableDTO} from "../_models/DTO/JobForTableDTO";
import {Subscription} from "rxjs";


@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.css']
})

export class JobComponent implements OnInit, OnDestroy {
  jobsTypeId: number;
  filter = {} as PaginatedRequest;
  allJobs: JobForTableDTO[];

  jobsSubscription: Subscription;
  routeParamsSubscription: Subscription;
  enrollJobSubscription: Subscription;
  jobsByTypeSubscription: Subscription;


  constructor(private jobService: JobService,
              private toolBarService: ToolBarService,
              route: ActivatedRoute, private chatService: ChatService) {
    this.routeParamsSubscription = route.params.subscribe((params: Params) => {
      this.jobsTypeId = Number(params.id);
    });
  }

  ngOnInit() {
    this.toolBarService.setTitle('Jobs');
    this.filter.pageSize = 100;
    this.jobsTypeId ? this.loadJobsByTypeId(this.jobsTypeId) : this.loadJobs();
  }

  onFiltered(filter: PaginatedRequest) {
    this.filter = Object.assign(this.filter, filter);
    this.jobsTypeId ? this.loadJobsByTypeId(this.jobsTypeId) : this.loadJobs();
  }

  onSearch(requestFilters) {
    this.filter.requestFilters = requestFilters;
    this.jobsTypeId ? this.loadJobsByTypeId(this.jobsTypeId) : this.loadJobs();
  }

  loadJobsByTypeId(id: number) {
    this.jobsByTypeSubscription = this.jobService.getAllJobPaginatedByType(this.filter, id).subscribe(data => {
      this.allJobs = data.items;
    });
  }

  loadJobs() {
    this.jobsSubscription = this.jobService.getAllJobPaginated(this.filter).subscribe(data => {
      this.allJobs = data.items;
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

