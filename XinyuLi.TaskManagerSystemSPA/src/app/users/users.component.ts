import { DOCUMENT } from '@angular/common';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { UserService } from '../core/services/user.service';
import { User } from '../shared/models/user';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users: User[];
  title = "Tasks View";


  constructor(private userService: UserService,
    private route : ActivatedRoute, 
      private router : Router) {}
  ngOnInit(): void {
    this.userService.getAllUsers().subscribe((u) => {
      this.users = u;
    });
  }

  
 locationreload() {    
   window.location.reload();        
    } 

  delete(id:number){
    this.userService.delete(id).subscribe(
      );
    this.locationreload();    
  }
}
