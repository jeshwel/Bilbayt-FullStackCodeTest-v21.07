import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";
import { AlertService } from "src/app/services/alert.service";
import { UserService } from "src/app/services/user.service";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(
    private router: Router,
    private alertService: AlertService,
    private userService: UserService
  ) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const idToken = sessionStorage.getItem("id_token");
    if (idToken) {
      req = req.clone({
        headers: req.headers.set("Authorization", "Bearer " + idToken),
      });
    }
    return next.handle(req).pipe(
      tap(
        () => {},
        (err: any) => {
          if (err instanceof HttpErrorResponse) {
            if (err.status !== 401) {
              return;
            }
            //Clears other session items and redirects to base page.
            this.userService.logout();
            this.alertService.showAlert("error", err.message);
          }
        }
      )
    );
  }
}
