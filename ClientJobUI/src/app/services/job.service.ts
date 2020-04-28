import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {PaginatedRequest} from '../models/PaginatedRequest';
import {JobDTO} from '../models/JobDTO';
import {PagedResult} from '../models/PagedResult';
import {Category} from '../models/Category';
import {City} from '../models/City';

const urlJob = 'http://localhost:5000/Job';

@Injectable({
  providedIn: 'root'
})

export class JobService {

  constructor(private http: HttpClient) {

  }
  getJobById(id: number) {
    return this.http.get<JobDTO>(`${urlJob}/${id}`);
  }

  getAllJobPaginated(paginatedRequest: PaginatedRequest): Observable<PagedResult<JobDTO>> {
    return this.http.post<PagedResult<JobDTO>>(`${urlJob}/PagePerTable`, paginatedRequest);
  }

  getAllJobPaginatedUser(paginatedRequest: PaginatedRequest): Observable<PagedResult<JobDTO>> {
    return this.http.post<PagedResult<JobDTO>>(`${urlJob}/PagePerTableForEmployer`, paginatedRequest);
  }

  getCategories(): Observable<Category[]>{
    return  this.http.get<Category[]>(`${urlJob}/Categories`);
  }

  getCity(): Observable<City[]>{
    return  this.http.get<City[]>(`${urlJob}/City`);
  }

  addjob(job: JobDTO): Observable<any> {
    return  this.http.post(`${urlJob}`, job);
  }

  deleteJob(id: number): Observable<any>{
    return  this.http.delete(`${urlJob}/${id}`);
  };

  editJob(job: JobDTO,id: number): Observable<any>{
    return  this.http.put(`${urlJob}/Update/${id}`, job);
  };
}
