import { Injectable } from '@angular/core';
import {HttpClient } from '@angular/common/http';
import {Job} from '../job/job.model';
import {Observable} from 'rxjs';
import { JobGridRow } from '../models/JobGridRow';
import { PaginatedRequest } from '../models/PaginatedRequest';
import { PagedResult } from '../models/PagedResult';


const urlJob="http://localhost:5000/Job";


@Injectable({
  providedIn: 'root'
})
export class JobService {

  constructor(private http:HttpClient) {

  }
  
  getAllJobs() : Observable<Job[]>{
    return  this.http.get<Job[]>(urlJob);
  }

  getJobById(id:number){
    return this.http.get<Job>(`${urlJob}/${id}`);
  }

  getJobsByCategory(category: string){
    return this. http.get<Job>(`${urlJob}/${category}`);
  }

  getJobsPaged(request : PaginatedRequest) : Observable<PagedResult<JobGridRow>>{
    return this.http.post<PagedResult<JobGridRow>>(`${urlJob}+"Job/PagePerTable"`, request);
  }






}
