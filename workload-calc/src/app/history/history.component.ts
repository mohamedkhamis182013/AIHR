import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { historyObject } from '../interfaces/history-object';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html',
  styleUrls: ['./history.component.css']
})
export class HistoryComponent implements OnInit {

  historyList :historyObject[]=[];
	constructor(private apiService: ApiService) { }
	ngOnInit() {
		this.apiService.get("/calculation").subscribe((data: any)=>{  
		debugger
		console.log(data)
			this.historyList = data.calculations;  
		})  
	}

}
