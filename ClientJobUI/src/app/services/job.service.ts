import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {PaginatedRequest} from '../model/PaginatedRequest';
import {PagedResult} from '../model/PagedResult';
import {Job} from '../model/Job';
import {JobRowRequest} from '../model/JobRowRequest';


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

  getJobsByCategory(category: string) {
    return this.http.get<Job>(`${urlJob}/${category}`);
  }

  getAllJobPaginated(paginatedRequest: PaginatedRequest): Observable<PagedResult<JobRowRequest>> {
    return this.http.post<PagedResult<JobRowRequest>>(`${urlJob}/PagePerTable`, paginatedRequest);
  }
}

