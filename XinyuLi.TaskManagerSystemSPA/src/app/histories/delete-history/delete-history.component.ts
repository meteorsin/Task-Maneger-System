import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaskHistoryService } from 'src/app/core/services/history.service';


@Component({
  selector: 'app-delete-history',
  templateUrl: './delete-history.component.html',
  styleUrls: ['./delete-history.component.css']
})
export class DeleteHistoryComponent implements OnInit {

  constructor(private historyService: TaskHistoryService,
    private route: ActivatedRoute) {}

  taskId:number;

  ngOnInit(): void {
    this.route.paramMap.subscribe((p) => {
      this.taskId = +p.get('id');
      console.log(this.taskId);
    });
    this.delete();
  }

  delete(){
    this.historyService.delete(this.taskId).subscribe(resp => {
      console.log("hi");
    });
  };

}
