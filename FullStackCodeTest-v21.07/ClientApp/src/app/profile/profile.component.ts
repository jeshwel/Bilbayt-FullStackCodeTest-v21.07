import { HttpErrorResponse } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { User } from "../models/user.model";
import { AlertService } from "../services/alert.service";
import { UserService } from "../services/user.service";

@Component({
  selector: "app-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.css"],
})
export class ProfileComponent implements OnInit {
  user$: Observable<User>;

  constructor(
    private userService: UserService,
    private alertService: AlertService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.getUserInfo();
  }

  private getUserInfo() {
    const id = this.route.snapshot.paramMap.get("id");

    this.user$ = this.userService.getUserInfo$(id).pipe(
      catchError((e: HttpErrorResponse) => {
        this.alertService.showAlert("error", e.message);
        return of(undefined);
      })
    );
  }
}
