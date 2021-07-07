import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "../models/user.model";
import { map, tap } from "rxjs/operators";
import * as moment from "moment";
import jwt_decode from "jwt-decode";
import { BehaviorSubject, Observable } from "rxjs";
import { Router } from "@angular/router";

@Injectable({
  providedIn: "root",
})
export class UserService {
  //Create the data which we want to share with all the components
  private loginStatus = new BehaviorSubject(this.isLoggedIn());
  //Now we want to broadcast this message or data, so we create an observable
  getLoginStatus$ = this.loginStatus.asObservable();
  constructor(private http: HttpClient, private router: Router) {}

  login$(userName: string, password: string) {
    return this.http
      .post("/api/user/login", { userName, password }, { responseType: "text" })
      .pipe(
        map((res) => {
          var userId = this.setSession(res);
          return userId;
        })
      );
  }

  register$(user: User) {
    return this.http.post("/api/user/register", user);
  }

  getUserInfo$(id: string): Observable<User> {
    return this.http.get<User>(`/api/user/${id}`);
  }

  private setSession(token) {
    var decodedToken = jwt_decode(token);
    const expiresAt = moment().add(decodedToken["exp"], "minutes");
    sessionStorage.setItem("id_token", token);
    sessionStorage.setItem("id", decodedToken["id"]);
    sessionStorage.setItem("expires_at", JSON.stringify(expiresAt.valueOf()));
    this.loginStatus.next(true);
    return decodedToken["id"];
  }

  logout() {
    sessionStorage.removeItem("id_token");
    sessionStorage.removeItem("expires_at");
    sessionStorage.removeItem("id");
    this.loginStatus.next(false);
    this.router.navigateByUrl("/");
  }

  public isLoggedIn() {
    return moment().isBefore(this.getExpiration());
  }

  isLoggedOut() {
    return !this.isLoggedIn();
  }

  getExpiration() {
    const expiration = sessionStorage.getItem("expires_at");
    const expiresAt = JSON.parse(expiration);
    return moment(expiresAt);
  }
}
