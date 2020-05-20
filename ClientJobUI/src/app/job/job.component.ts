import {Component, OnInit} from '@angular/core';
import {JobService} from '../_services/job.service';
import {ToolBarService} from '../_services/toolbar.service.service';
import {JobDTO} from '../_models/DTO/JobDTO';
import {PaginatedRequest} from '../_models/PaginatedRequest';
import {ActivatedRoute, Params} from '@angular/router';
import { ChatService } from '../_services/chat.service';
import {JobForTableDTO} from "../_models/DTO/JobForTableDTO";


@Component({
  selector: 'app-job',
  templateUrl: './job.component.html',
  styleUrls: ['./job.component.css']
})

export class JobComponent implements OnInit {
  jobsTypeId: number;
  filter = {} as PaginatedRequest;
  allJobs: JobForTableDTO[];


  constructor(private jobService: JobService,
              private toolBarService: ToolBarService,
              route: ActivatedRoute, private chatService: ChatService) {
    route.params.subscribe((params: Params) => {
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
    this.jobService.getAllJobPaginatedByType(this.filter, id).subscribe(data => {
      this.allJobs = data.items;
    });
  }

  loadJobs() {
    this.jobService.getAllJobPaginated(this.filter).subscribe(data => {
      this.allJobs = data.items;
    });
  }

  subscribe(jobId:number){
    this.jobService.addJobStudent(jobId).subscribe();
  }

  onChat(job: JobForTableDTO){
    this.chatService.newChat(job);
  }
}

