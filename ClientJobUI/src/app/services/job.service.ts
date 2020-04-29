import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {PaginatedRequest} from '../models/PaginatedRequest';
import {JobDTO} from '../models/DTO/JobDTO';
import {PagedResult} from '../models/PagedResult';
import {CategoryDTO} from '../models/DTO/CategoryDTO';
import {CityDTO} from '../models/DTO/CityDTO';

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

  getCategories(): Observable<CategoryDTO[]>{
    return  this.http.get<CategoryDTO[]>(`${urlJob}/Categories`);
  }

  getCity(): Observable<CityDTO[]>{
    return  this.http.get<CityDTO[]>(`${urlJob}/City`);
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
