import { Component, Inject } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { HomeService } from './home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [HomeService]
})
export class HomeComponent {

  username: string = null;
  password: string = null;
  token: string = null;
  loginSuccess: boolean = false;
  welcomeMessage: string = null;


  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private service: HomeService) {
    if (this.service.getUserLoggedIn() != null) {
      this.username = this.service.getUserLoggedIn();
      this.loginSuccess = true;
      this.welcomeMessage = "Welcome " + this.username + "!";
    }
  }

  onSubmit() {
    this.service.login(this.username, this.password).subscribe(x => {
      this.token = this.service.getToken();
      if (this.token != null) {
        this.loginSuccess = true;
        this.welcomeMessage = "Welcome " + this.username + "!";
      }
    });

    
  }

  logout() {
    sessionStorage.clear();
    this.loginSuccess = false;

  }
}
