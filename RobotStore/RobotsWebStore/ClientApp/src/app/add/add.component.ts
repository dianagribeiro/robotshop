import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Robot } from '../Robot';
import { HomeService } from '../home/home.service';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  providers: [HomeService]
})
export class AddComponent {

  
  robot: any = {};

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private service: HomeService) {
   
  }

  

  onSubmit() {
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

