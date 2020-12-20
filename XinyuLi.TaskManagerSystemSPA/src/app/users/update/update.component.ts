import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/core/services/user.service';
import { ActivatedRoute } from '@angular/router';
import { User } from "src/app/shared/models/user";
import {Router} from '@angular/router';

@Component({
  selector: 'app-update',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {

  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private r: Router
    ) { }

  userId:number;
  user: User ={
    email:'',
    password:'',
    fullname:'',
    mobileno:''
  }
  
  ngOnInit(): void {
    this.route.paramMap.subscribe((p) => {
      this.userId = +p.get('id');
      console.log(this.userId);
    });
  }

  update(){
    this.userService.update(this.user, this.userId).subscribe(resp => {
      console.log(resp);
    });
    this.r.navigateByUrl('/users');
  };
}
