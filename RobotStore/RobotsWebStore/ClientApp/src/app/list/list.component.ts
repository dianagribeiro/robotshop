import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HomeService } from '../home/home.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-list-component',
  templateUrl: './list.component.html',
  providers: [HomeService]
})
export class ListComponent {

  public robots: Robot[];
  public robot: Robot;
  getSuccess: boolean = false;
  id: number;
  

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private service: HomeService, private router: Router) {
    this.getListRobots();
  }

  getListRobots() {

    if (this.service.getToken() == null) {
      alert("You need to login to access the application.");
      this.router.navigate(['/']);
    } else {
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
          'JwtToken': this.service.getToken()
        })
      };

      this.http.get<Robot[]>(this.baseUrl + 'api/robot/list', httpOptions).subscribe(result => {
        this.robots = result;
      }, error => console.error(error));
    }
  }

  getRobot() {

    if (this.service.getToken() == null) {
      alert("You need to login to access the application.");
      this.router.navigate(['/']);
    } else {
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
          'JwtToken': this.service.getToken()
        })
      };

      this.http.get<Robot>(this.baseUrl + 'api/robot/get/' + this.id, httpOptions).subscribe(result => {
        this.robot = result;
        this.getSuccess = true;
      }, error => console.error(error));
    }
  }

  deleteRobot(id: number) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'JwtToken': this.service.getToken()
      })
    };

    this.http.delete(this.baseUrl + 'api/robot/delete/' + id, httpOptions).subscribe(() => {
        this.getListRobots();
    }, error => alert("Unauthorized"));
  }

}

interface Robot {
  id: number;
  name: string;
  price: string;
}
