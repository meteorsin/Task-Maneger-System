import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaskService } from 'src/app/core/services/task.service';
import { Task } from 'src/app/shared/models/task';

@Component({
  selector: 'app-by-user-id',
  templateUrl: './by-user-id.component.html',
  styleUrls: ['./by-user-id.component.css']
})
export class ByUserIdComponent implements OnInit {

  constructor(private taskService: TaskService,
    private route: ActivatedRoute) {}
    userId:number;
    tasks: Task[];


  ngOnInit(): void {
    this.route.paramMap.subscribe((p) => {
      this.userId = +p.get('id');
      console.log(this.userId);
    });
    this.taskService.getTasksByUserid(this.userId).subscribe((t) => {
      this.tasks = t;
    });
  }
  
  locationreload() {    
    window.location.reload();        
     } 
 
   delete(id:number){
     this.taskService.delete(id).subscribe(
       );
     this.locationreload();
   }

    

}
