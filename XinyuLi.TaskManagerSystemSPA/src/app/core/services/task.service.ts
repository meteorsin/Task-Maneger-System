import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { Task } from "src/app/shared/models/task";

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor(private apiService: ApiService) { }

  getAllTasks(): Observable<Task[]> {    
    return this.apiService.getAll('tasks');
  }

  getTasksByUserid(id:number){
    return this.apiService.getByForeignKey('tasks', "user",id)
  }

  create(task: Task): Observable<any> {
    return this.apiService.create('tasks/create', task);
  }

  update( task: Task, id:number ): Observable<any> {
    return this.apiService.update('tasks/update', task, id);
  }

  delete(id:number):Observable<any>{
    return this.apiService.delete('tasks/delete', id);
  }
}