import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-list-component',
  templateUrl: './list.component.html'
})
export class ListComponent {
  //public currentCount = 0;

  public robots: Robot[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.getListRobots();
  }

  getListRobots() {
    this.http.get<Robot[]>(this.baseUrl + 'api/robot/list').subscribe(result => {
      this.robots = result;
    }, error => console.error(error));
  }

  deleteRobot(id: number) {
    this.http.delete(this.baseUrl + 'api/robot/delete/' + id).subscribe(() => {
        this.getListRobots();
    }, error => console.error(error));
  }

  //public incrementCounter() {
  //  this.currentCount++;
  //}
  
}

interface Robot {
  id: number;
  name: string;
  price: string;
}
