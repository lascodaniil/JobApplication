import {Injectable} from '@angular/core';
import {HttpClient, HttpResponse} from '@angular/common/http';
import {Observable} from 'rxjs';
import {PaginatedRequest} from '../_models/PaginatedRequest';
import {JobDTO} from '../_models/DTO/JobDTO';
import {PagedResult} from '../_models/PagedResult';
import {CategoryDTO} from '../_models/DTO/CategoryDTO';
import {CityDTO} from '../_models/DTO/CityDTO';
import {JobType} from '../_models/JobType';
import {JobForViewDTO} from "../_models/DTO/JobForViewDTO";
import {JobForTableDTO} from "../_models/DTO/JobForTableDTO";

const urlJob = 'http://localhost:5000/Job';



@Injectable({
  providedIn: 'root'
})

export class JobService {

  constructor(private http: HttpClient) {

  }

  getAllJobs() : Observable<JobForViewDTO[]>{
    return this.http.get<JobDTO[]>(`${urlJob}`);
  }

  getJobById(id: number) {
    return this.http.get<JobForTableDTO>(`${urlJob}/${id}`);
  }
  getAllJobPaginated(paginatedRequest: PaginatedRequest): Observable<PagedResult<JobForTableDTO>> {
    return this.http.post<PagedResult<JobForTableDTO>>(`${urlJob}/PagePerTable`, paginatedRequest);
  }

  getAllJobPaginatedEmployer(paginatedRequest: PaginatedRequest): Observable<PagedResult<JobForTableDTO>> {
    return this.http.post<PagedResult<JobForTableDTO>>(`${urlJob}/Profile`, paginatedRequest);
  }

  getAllJobPaginatedStudent(paginatedRequest: PaginatedRequest): Observable<PagedResult<JobForViewDTO>> {
    return this.http.post<PagedResult<JobForViewDTO>>(`${urlJob}/Profile/Student`, paginatedRequest);
  }

  getAllJobPaginatedByType(paginatedRequest: PaginatedRequest, typeId :number): Observable<PagedResult<JobForTableDTO>> {
    return this.http.post<PagedResult<JobForTableDTO>>(`${urlJob}/Types/${typeId}`, paginatedRequest);
  }

  getCategories(): Observable<CategoryDTO[]>{
    return  this.http.get<CategoryDTO[]>(`${urlJob}/Categories`);
  }

  getCity(): Observable<CityDTO[]>{
    return  this.http.get<CityDTO[]>(`${urlJob}/City`);
  }

  AddJobFormData(formData : any) : Observable<any> {
    return  this.http.post(`${urlJob}/Post`, formData);
  }
  deleteJob(id: number): Observable<any>{
    return  this.http.delete(`${urlJob}/${id}`);
  };

  editJob(job: any,id: number): Observable<any>{
    return  this.http.put(`${urlJob}/Update/${id}`, job);
  };

  getJobsTypes() : Observable<JobType[]>{
    return  this.http.get<JobType[]>(`${urlJob}/Types`);
  }

  deleteEnrolledJobForStudent(id:number) : Observable<any>{
    return  this.http.delete(`${urlJob}/Student/Delete/${id}`);
  }
  addJobStudent(id:number) : Observable<any>{
    return  this.http.get(`${urlJob}/Added/${id}`);
  }

  getImage(id : number) : Observable<Blob>{
    return  this.http.get(`${urlJob}/Image/${id}`,
      { responseType: 'blob'});
  }
}
