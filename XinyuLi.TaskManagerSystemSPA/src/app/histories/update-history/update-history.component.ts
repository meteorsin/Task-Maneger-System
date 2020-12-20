import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TaskHistoryService } from 'src/app/core/services/history.service';
import { TaskHistory } from 'src/app/shared/models/history';

@Component({
  selector: 'app-update-history',
  templateUrl: './update-history.component.html',
  styleUrls: ['./update-history.component.css']
})
export class UpdateHistoryComponent implements OnInit {

  constructor(
    private historyService: TaskHistoryService,
    private route: ActivatedRoute,
    private r: Router
    ) { }

    taskId:number;
    history: TaskHistory ={
      taskId: 0,
      userId: undefined,
      title: '',
      description: '',
      duedate: '',
      completed:'',
      remarks:''
    }
  ngOnInit(): void {
    this.route.paramMap.subscribe((p) => {
      this.taskId = +p.get('id');
      console.log(this.taskId);
    })
  }
  update(){
    this.historyService.update(this.history, this.taskId).subscribe(resp => {
      console.log(resp);
    });
    this.r.navigateByUrl('/taskhistories');
  }
}
