import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/core/services/user.service';
import { ActivatedRoute } from '@angular/router';
import { User } from "src/app/shared/models/user";

@Component({
  selector: 'app-delete',
  templateUrl: './delete.component.html',
  styleUrls: ['./delete.component.css']
})
export class DeleteComponent implements OnInit {

  constructor(
    private userService: UserService,
    private route: ActivatedRoute
    ) { 

    }
  
  userId:number;

  ngOnInit(): void {
    this.route.paramMap.subscribe((p) => {
      this.userId = +p.get('id');
      console.log(this.userId);
    });
    this.delete();
  }

  delete(){
    this.userService.delete(this.userId).subscribe(resp => {
      console.log("hi");
    });
  };
}
