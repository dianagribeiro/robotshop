import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Robot } from '../Robot';
import { HomeService } from '../home/home.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  providers: [HomeService]
})
export class AddComponent {

  
  robot: any = {};

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private service: HomeService, private router: Router) {
    if (this.service.getToken() == null) {
      alert("You need to login to access the application.");
      this.router.navigate(['/']);
    } 
   
  }

  

  onSubmit() {
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
      this.http.post<any>("api/robot/add",
        {
          Name: this.robot.name,
          Price: this.robot.price
        }, httpOptions).subscribe(() => {
          alert("Robot added with success! You can click on List to see the updated robots.")
        }, error => alert("Unauthorized"));

    }
  }
}

