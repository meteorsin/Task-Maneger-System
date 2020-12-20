import { Component, Input, OnInit } from '@angular/core';
import { TaskHistoryService } from '../core/services/history.service';
import { TaskHistory } from '../shared/models/history';

@Component({
  selector: 'app-history',
  templateUrl: './histories.component.html',
  styleUrls: ['./histories.component.css']
})
export class HistoriesComponent implements OnInit {

  histories: TaskHistory[];

  constructor(private historyService: TaskHistoryService) {}
  ngOnInit(): void {
    console.log("hi")
    this.historyService.getAllHistories().subscribe((h) => {
      this.histories = h;
    });
  }

  locationreload() {    
    window.location.reload();        
     } 
 
   delete(id:number){
     this.historyService.delete(id).subscribe(
       );
     this.locationreload();
   }
}
