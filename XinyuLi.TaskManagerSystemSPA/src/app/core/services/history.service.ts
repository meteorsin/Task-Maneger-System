import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { TaskHistory } from "src/app/shared/models/history";

@Injectable({
  providedIn: 'root'
})
export class TaskHistoryService {

  constructor(private apiService: ApiService) { }

  getAllHistories(): Observable<TaskHistory[]> {    
    return this.apiService.getAll('taskhistories');
  }

  create(history: TaskHistory): Observable<any> {
    return this.apiService.create('taskhistories/create', history);
  }

  update( history: TaskHistory, id:number ): Observable<any> {
    return this.apiService.update('taskhistories/update', history, id);
  }

  delete(id:number):Observable<any>{
    return this.apiService.delete('taskhistories/delete', id);
  }
}