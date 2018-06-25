import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { SnackerService } from './snacker.service';
import { User } from '../models/user';

@Injectable()
export class AppService {
  private user = new BehaviorSubject<User>(null);
  private filteredUsers = new BehaviorSubject<User[]>(null);
  user$ = this.user.asObservable();
  filteredUsers$ = this.filteredUsers.asObservable();

  constructor(
    private http: HttpClient,
    private snacker: SnackerService
  ) { }

  getCurrentUser = () => {
    this.http.get<User>('/api/app/getCurrentUser')
      .subscribe(
        data => this.user.next(data),
        err => this.snacker.sendErrorMessage(err.error)
      );
  }

  filterUsers = (filter: string) => {
    this.http.get<User[]>(`/api/app/filterUsers/${filter}`)
      .subscribe(
        data => this.filteredUsers.next(data),
        err => this.snacker.sendErrorMessage(err.error)
      );
  }

  resetFilteredUsers = () => this.filteredUsers.next(null);
}
