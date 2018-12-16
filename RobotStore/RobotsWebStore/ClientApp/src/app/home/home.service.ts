import { Component, Inject, Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';

@Injectable()
export class HomeService {

  loginSuccess: boolean = false;
  welcomeMessage: string = null;
  token: string = null;


  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  login(username: string, password: string) {
    return this.http.get<LoginResult>(this.baseUrl + 'api/user/login?username=' + username + '&password=' + password)
      .map(x => {

        sessionStorage.setItem("token", x.data);
        sessionStorage.setItem("username", x.username);
      }
      );
  }

  getToken() {
    return sessionStorage.getItem("token");
  }

  getUserLoggedIn() {
    return sessionStorage.getItem("username");
  }
}

interface LoginResult {
  data: string;
  username: string;
}
