import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { take } from "rxjs/operators";
import { AlertService } from "../services/alert.service";
import { UserService } from "../services/user.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loginStatus = false;
  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private alertService: AlertService,
    private router: Router
  ) {
    this.loginForm = fb.group({
      userName: ["", Validators.required],
      password: ["", Validators.required],
    });
  }

  ngOnInit() {
    this.userService.getLoginStatus$.subscribe((data) => {
      this.loginStatus = data;
    });
  }

  login() {
    const val = this.loginForm.value;
    this.userService
      .login$(val.userName, val.password)
      .pipe(take(1))
      .subscribe(
        (id) => {
          this.router.navigateByUrl("/profile/" + id);
        },
        (error) => this.alertService.showAlert("error", error.error)
      );
  }
}
