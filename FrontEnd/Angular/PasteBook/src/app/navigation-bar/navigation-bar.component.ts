import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../security/auth.service';
import { UserAuth } from '../security/Model/user-auth';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.scss']
})
export class NavigationBarComponent implements OnInit {

  constructor(private authService: AuthService, private router: Router) { }

  user: UserAuth = {};

  ngOnInit(): void {
    this.user = this.authService.getLoggedInUser()!;
  }

  logout(){
    this.authService.logout();
    this.router.navigate(['login']);
  }
}
