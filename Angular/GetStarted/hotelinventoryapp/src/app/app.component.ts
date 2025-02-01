import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { RoomsComponent } from './rooms/rooms.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RoomsComponent, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'hotelinventoryapp';

  role = "Admin";
}
