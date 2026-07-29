import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DataService } from '../app/data.service';
import { ChildComponent } from './child/child.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, ChildComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  constructor(private dataService: DataService) { }

  title = 'FirstAngularApp';

  sendData() {
    this.dataService.setData('Hello from Parent Component!');
  }
}
