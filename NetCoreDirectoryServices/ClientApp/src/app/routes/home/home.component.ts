import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { fromEvent } from 'rxjs';
import { distinctUntilChanged, debounceTime } from 'rxjs/operators';
import { AppService } from '../../services/app.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [AppService]
})
export class HomeComponent implements OnInit {
  @ViewChild('filterInput') filterInput: ElementRef;

  constructor(
    public service: AppService
  ) { }

  ngOnInit() {
    this.service.getCurrentUser();
    fromEvent(this.filterInput.nativeElement, 'keyup')
      .pipe(
        debounceTime(250),
        distinctUntilChanged()
      )
      .subscribe(
        (data: any) => {
          if (!(data.target.value)) {
            this.service.resetFilteredUsers();
            return;
          }

          this.service.filterUsers(data.target.value);
        }
      );
  }
}
