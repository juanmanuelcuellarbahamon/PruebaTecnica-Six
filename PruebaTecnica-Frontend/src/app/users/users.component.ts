import { Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

import { UserService } from '../service/users.service';
import { User } from '../interfaces/user.interface';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [CommonModule, MatTableModule, MatButtonModule, MatProgressSpinnerModule],
  templateUrl: './users.html',
  styleUrls: ['./users.css']
})
export class UsersComponent {
  displayedColumns: string[] = ['usuID', 'nombreCompleto'];

  dataSource = signal<User[]>([]);
  showTable = signal(false);
  isLoading = signal(false);
  errorMessage = signal('');

  constructor(private userService: UserService) {}

  loadUsers() {
    this.isLoading.set(true);
    this.errorMessage.set('');
    this.showTable.set(false);

    this.userService.getUsers().subscribe({
      next: (users) => {
        this.dataSource.set(users);
        this.showTable.set(true);
        this.isLoading.set(false);
      },
      error: (err) => {
        this.errorMessage.set('Error loading users: ' + err.message);
        this.isLoading.set(false);
        this.showTable.set(false);
      }
    });
  }
}
