import { Injectable } from '@angular/core';
import {HttpClient } from '@angular/common/http';
import {Observable} from 'rxjs';
import { PaginatedRequest } from '../model/PaginatedRequest';
import { PagedResult } from '../model/PagedResult';
import { Job } from '../model/Job';
import { JobRow } from '../job/JobRow.model';


const urlJob="http://localhost:5000/Job";


@Injectable({
  providedIn: 'root'
})
export class JobService {

  constructor(private http:HttpClient) {
  
  }


  getJobById(id:number){
    return this.http.get<JobRow>(`${urlJob}/${id}`);
  }

  getJobsByCategory(category: string){
    return this. http.get<JobRow>(`${urlJob}/${category}`);
  }

  getAllJobs(paginatedRequest: PaginatedRequest) : Observable<PagedResult<JobRow>>{
    return this.http.post<PagedResult<JobRow>>(`${urlJob}/PagePerTable`, paginatedRequest);
  }
}

