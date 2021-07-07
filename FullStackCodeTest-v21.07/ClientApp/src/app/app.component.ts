import { Component, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { AlertService } from "./services/alert.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
})
export class AppComponent implements OnInit {
  alert$: Observable<any>;
  alert2: any;
  title = "app";

  constructor(private alertService: AlertService) {}

  ngOnInit() {
    this.alert$ = this.alertService.getAlertObs$; //.subscribe((data) => {
    //     console.log(data);
    //     this.alert2 = data;
    //   });
  }
}
