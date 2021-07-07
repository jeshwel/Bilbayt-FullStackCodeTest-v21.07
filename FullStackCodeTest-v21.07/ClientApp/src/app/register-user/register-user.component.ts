import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { take } from "rxjs/operators";
import { AlertService } from "../services/alert.service";
import { UserService } from "../services/user.service";

@Component({
  selector: "app-register-user",
  templateUrl: "./register-user.component.html",
  styleUrls: ["./register-user.component.css"],
})
export class RegisterUserComponent implements OnInit {
  userForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private alertService: AlertService,
    private userService: UserService,
    private router: Router
  ) {
    this.userForm = fb.group({
      userName: ["", Validators.required],
      password: ["", Validators.required],
      fullName: ["", Validators.required],
      email: ["", Validators.required],
    });
  }

  ngOnInit() {}

  register() {
    const val = this.userForm.value;
    this.userService
      .register$(val)
      .pipe(take(1))
      .subscribe(
        (id) => {
          this.alertService.showAlert(
            "success",
            "Your account has been created, please login."
          );
          setTimeout(() => {
            this.router.navigateByUrl("/");
          }, 4000);
        },
        (error) => this.alertService.showAlert("error", error.error)
      );
  }
}
