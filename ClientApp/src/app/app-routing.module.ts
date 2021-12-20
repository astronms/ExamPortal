import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';
import { ExamsComponent } from './student/components/exams/exams.component';
import { ExamComponent } from './student/components/exam/exam.component';
import { ExamSessionsListComponent } from './teacher/components/exam-sessions-list/exam-sessions-list.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';

import { AuthGuard } from './guards/auth-guard.service';
import { RoleEnum } from './enums/role.enum';

const appRoutes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'student/exams', component: ExamsComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.User}},
  { path: 'student/exam', component: ExamComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.User}},
  { path: 'teacher/exams', component: ExamSessionsListComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.Admin}},
  { path: '**', component: PageNotFoundComponent }
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(appRoutes)
  ],
  exports: [
    RouterModule
  ]
})

export class AppRoutingModule { }
