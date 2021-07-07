import { Component, OnInit } from "@angular/core";
import { UserService } from "../services/user.service";

@Component({
  selector: "app-nav-menu",
  templateUrl: "./nav-menu.component.html",
  styleUrls: ["./nav-menu.component.css"],
})
export class NavMenuComponent implements OnInit {
  loginStatus = false;
  isExpanded = false;
  constructor(private userService: UserService) {}

  ngOnInit() {
    this.userService.getLoginStatus$.subscribe((data) => {
      this.loginStatus = data;
    });
  }

  logout() {
    this.userService.logout();
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
