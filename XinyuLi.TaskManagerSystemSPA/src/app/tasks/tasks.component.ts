import { Component, Input, OnInit } from '@angular/core';
import { TaskService } from '../core/services/task.service';
import { Task } from '../shared/models/task';

@Component({
  selector: 'app-task',
  templateUrl: './tasks.component.html',
  styleUrls: ['./tasks.component.css']
})
export class TaskComponent implements OnInit {

  tasks: Task[];
  title = "Tasks View";

  constructor(private taskService: TaskService) {}
  ngOnInit(): void {
    this.taskService.getAllTasks().subscribe((t) => {
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
