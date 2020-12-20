import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskService } from 'src/app/core/services/task.service';
import { Task } from 'src/app/shared/models/task';

@Component({
  selector: 'app-update-task',
  templateUrl: './update-task.component.html',
  styleUrls: ['./update-task.component.css']
})
export class UpdateTaskComponent implements OnInit {

  constructor(
    private taskService: TaskService,
    private route: ActivatedRoute,
    private r: Router
    ) { }

    
  taskId:number;
    task: Task ={
      userId: undefined,
      title: '',
      description: '',
      duedate: '',
      priority:'',
      remarks:''
    }
  ngOnInit(): void {
    this.route.paramMap.subscribe((p) => {
      this.taskId = +p.get('id');
      console.log(this.taskId);
    })
  }

  update(){
    this.taskService.update(this.task, this.taskId).subscribe(resp => {
      console.log(resp);
    });
    this.r.navigateByUrl('/tasks');
    
  };

}
