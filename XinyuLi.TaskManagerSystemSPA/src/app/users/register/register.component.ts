import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/core/services/user.service';
import { User } from "src/app/shared/models/user";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  userRegister: User ={
    email:'',
    password:'',
    fullname:'',
    mobileno:''
  }
  constructor(private userService: UserService,
    private r: Router) { }

  ngOnInit(): void {
  }
  
  register(){
    this.userService.register(this.userRegister).subscribe( 
    
    )
    this.r.navigateByUrl('/taskhistories');
  };
}
