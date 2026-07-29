import { Component } from '@angular/core';
import { DataService } from '../data.service'; // Import the service

@Component({
  selector: 'app-child',
  imports: [],
  templateUrl: './child.component.html',
  styleUrl: './child.component.css'
})
export class ChildComponent {
  receivedData: string = '';

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.receivedData = this.dataService.getData(); // Get shared data
  }
}
