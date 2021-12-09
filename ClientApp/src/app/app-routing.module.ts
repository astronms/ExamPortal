import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { ExamsComponent } from './student/components/exams/exams.component';
import { ExamComponent } from './student/components/exam/exam.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';

import { AuthGuard } from './guards/auth-guard.service';
import { RoleEnum } from './enums/role.enum';

const appRoutes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'exams', component: ExamsComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.User}},
  { path: 'exam', component: ExamComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.User}},
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
