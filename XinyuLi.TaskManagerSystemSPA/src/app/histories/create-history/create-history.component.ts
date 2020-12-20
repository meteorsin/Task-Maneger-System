import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TaskHistoryService } from 'src/app/core/services/history.service';
import { TaskHistory } from 'src/app/shared/models/history';

@Component({
  selector: 'app-create-history',
  templateUrl: './create-history.component.html',
  styleUrls: ['./create-history.component.css']
})
export class CreateHistoryComponent implements OnInit {

  constructor(private historyService: TaskHistoryService,
    private r: Router) { }

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
  }

  create(){
    this.historyService.create(this.history).subscribe(
    (response) => {
      console.log(this.history.duedate)

    }
    )
    this.r.navigateByUrl('/histories');
  };

}
