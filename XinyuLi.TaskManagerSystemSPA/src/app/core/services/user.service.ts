import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { User } from "src/app/shared/models/user";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private apiService: ApiService) { }

  getAllUsers(): Observable<User[]> {    
    return this.apiService.getAll('users');
  }

  register(userRegister: User): Observable<any> {
    return this.apiService.create('users/register', userRegister);
  }

  update( user: User, id:number ): Observable<any> {
    return this.apiService.update('users/update', user, id);
  }

  delete(id:number):Observable<any>{
    return this.apiService.delete('users/delete', id);
  }
}