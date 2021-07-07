import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class AlertService {
  alert: object = { type: null, message: null };
  private alertSub = new BehaviorSubject<object>(alert);
  getAlertObs$ = this.alertSub.asObservable();

  constructor() {}

  showAlert(type, message) {
    this.alert = { type, message };
    this.alertSub.next(this.alert);
    setTimeout(() => {
      this.alertSub.next(null);
    }, 4500);
  }
}
