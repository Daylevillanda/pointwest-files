import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../security/auth.service';
import { Login } from './Model/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  login: Login = {
    emailAddress: '',
    password: ''
  }
  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(){
    this.authService.login(this.login)
    .pipe()
    .subscribe(response => {
      if(response.token)
        this.router.navigateByUrl('/');
    });
  }
}
