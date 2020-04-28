import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {PaginatedRequest} from '../model/PaginatedRequest';
import {PagedResult} from '../model/PagedResult';
import {JobRowRequest} from '../model/JobRowRequest';
import {Category} from '../model/Category';
import {JobForPostDTO} from '../model/JobForPostDTO';
import {City} from '../model/City';


const urlJob = 'http://localhost:5000/Job';


@Injectable({
  providedIn: 'root'
})
export class JobService {

  constructor(private http: HttpClient) {

  }


  getJobById(id: number) {
    return this.http.get<JobForPostDTO>(`${urlJob}/Table/${id}`);
  }

  getAllJobPaginated(paginatedRequest: PaginatedRequest): Observable<PagedResult<JobRowRequest>> {
    return this.http.post<PagedResult<JobRowRequest>>(`${urlJob}/PagePerTable`, paginatedRequest);
  }

  getAllJobPaginatedUser(paginatedRequest: PaginatedRequest): Observable<PagedResult<JobRowRequest>> {
    return this.http.post<PagedResult<JobRowRequest>>(`${urlJob}/PagePerTableForEmployer`, paginatedRequest);
  }

  getCategories(): Observable<Category[]>{
    return  this.http.get<Category[]>(`${urlJob}/Categories`);
  }

  getCity(): Observable<City[]>{
    return  this.http.get<City[]>(`${urlJob}/City`);
  }

  addjob(job: JobForPostDTO): Observable<any> {
    return  this.http.post(`${urlJob}`, job);
  }

  deleteJob(id: number): Observable<any>{
    return  this.http.delete(`${urlJob}/${id}`);
  };

  editJob(job: JobForPostDTO,id: number): Observable<any>{
    return  this.http.put(`${urlJob}/Update/${id}`, job);
  };
}

