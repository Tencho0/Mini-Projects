import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private sharedData: string = 'Hello from Service!';

  constructor() { }

  getData() {
    return this.sharedData;
  }

  setData(newData: string) {
    this.sharedData = newData;
  }
}
