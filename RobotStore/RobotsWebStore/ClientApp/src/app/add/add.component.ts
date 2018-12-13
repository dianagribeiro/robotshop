import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Robot } from '../Robot';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html'
})
export class AddComponent {

  
  robot: any = {};

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
   
  }

  

  onSubmit() {

    this.http.post<any>("api/robot/add",
                {
                    Name: this.robot.name,
                    Price: this.robot.price
      }).subscribe(() => {
        alert("Robot added with success! You can click on List to see the updated robots.")
      }, error => console.error(error));
    
  }
}

