import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RoleEnum } from 'src/app/enums/role.enum';

import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: []
})
export class NavMenuComponent {
  isExpanded = false;
  userTypes : typeof RoleEnum = RoleEnum;

  teacher_items = {
    "Kursy": "teacher/courses-list",
    "Egzaminy": "teacher/exams-list"
  }

  student_items = {
    "Egzaminy": "student/exams-list"
  }

  constructor(private router: Router, public authService: AuthService ) { }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    this.authService.logOut();
    this.router.navigate(["/"]);
  }
}
