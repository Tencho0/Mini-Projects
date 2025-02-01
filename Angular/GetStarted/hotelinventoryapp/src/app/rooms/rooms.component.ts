import { Component } from '@angular/core';
import { Room, RoomList } from './rooms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-rooms',
  imports: [CommonModule],
  templateUrl: './rooms.component.html',
  styleUrl: './rooms.component.scss'
})
export class RoomsComponent {
  hotelName = 'Hilton Hotel';
  numberOfRooms = 10;

  hideRooms = false;

  rooms: Room = {
    totalRooms: 20,
    availableRooms: 10,
    bookedRooms: 5,
  };

  roomList: RoomList[] = [
    {
      roomNumber: 1,
      roomType: 'Deluxe Room',
      amenities: 'Air conditioner, Free Wi-Fi, TV, Bathroom, Kitchen',
      price: 500,
      photos: 'https://image/1.com',
      chekInTime: new Date('11-Nov-2021'),
      chekOutTime: new Date('12-Nov-2021')
    },
    {
      roomNumber: 2,
      roomType: 'Ultra Deluxe Room',
      amenities: 'Air conditioner, Free Wi-Fi, TV, Bathroom, Kitchen',
      price: 1500,
      photos: 'https://image/2.com',
      chekInTime: new Date('11-Nov-2021'),
      chekOutTime: new Date('12-Nov-2021')
    },
    {
      roomNumber: 3,
      roomType: 'Private Suite',
      amenities: 'Air conditioner, Free Wi-Fi, TV, Bathroom, Kitchen',
      price: 4500,
      photos: 'https://image.com',
      chekInTime: new Date('11-Nov-2021'),
      chekOutTime: new Date('12-Nov-2021')
    }
  ];

  toggle() {
    this.hideRooms = !this.hideRooms;
  }
}
