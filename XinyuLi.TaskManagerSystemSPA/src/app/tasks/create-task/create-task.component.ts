import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TaskService } from 'src/app/core/services/task.service';
import { Task } from 'src/app/shared/models/task';

@Component({
  selector: 'app-create-task',
  templateUrl: './create-task.component.html',
  styleUrls: ['./create-task.component.css']
})
export class CreateTaskComponent implements OnInit {

  task: Task ={
    userId: undefined,
    title: '',
    description: '',
    duedate: '',
    priority:'',
    remarks:''
  }

  constructor(private taskService: TaskService,
    private r: Router) { }

  ngOnInit(): void {
  }

  create(){
    this.taskService.create(this.task).subscribe(
    (response) => {
      console.log(this.task.duedate)

    }
    )
    this.r.navigateByUrl('/tasks');
  };

}
