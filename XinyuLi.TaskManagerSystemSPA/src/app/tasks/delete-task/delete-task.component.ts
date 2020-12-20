import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaskService } from 'src/app/core/services/task.service';

@Component({
  selector: 'app-delete-task',
  templateUrl: './delete-task.component.html',
  styleUrls: ['./delete-task.component.css']
})
export class DeleteTaskComponent implements OnInit {

  constructor(
    private taskService: TaskService,
    private route: ActivatedRoute
    ) { 

    }

    taskId:number;

  ngOnInit(): void {
    this.route.paramMap.subscribe((p) => {
      this.taskId = +p.get('id');
      console.log(this.taskId);
    });
    this.delete();
  }

  delete(){
    this.taskService.delete(this.taskId).subscribe(resp => {
      console.log("hi");
    });
  };
}
