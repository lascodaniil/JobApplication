import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {PaginatedRequest} from '../model/PaginatedRequest';
import {PagedResult} from '../model/PagedResult';
import {Job} from '../model/Job';
import {JobRowRequest} from '../model/JobRowRequest';
import {JobDTO} from '../model/JobDTO';
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
    return this.http.get<Job>(`${urlJob}/${id}`);
  }

  getAllJobsByUserId(UserId: number) {
    return this.http.get<JobDTO>(`${urlJob}/${UserId}`);
  }

  getJobsByCategory(category: string) {
    return this.http.get<Job>(`${urlJob}/${category}`);
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

  addNewJob(job: JobForPostDTO): Observable<any> {
    return  this.http.post(`${urlJob}`, job);
  }
}

