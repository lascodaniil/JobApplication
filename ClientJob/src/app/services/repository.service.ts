import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Job } from '../job/job.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RepositoryService {
  constructor(private http : HttpClient) { }
  
  getJobs():Observable<Job[]>{
    return this.http.get<Job[]>("http://localhost:5000/Job");
  }
}
