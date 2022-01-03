import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';
import { AboutComponent } from './components/about/about.component';
import { ExamsComponent } from './student/components/exams/exams.component';
import { ExamComponent } from './student/components/exam/exam.component';
import { ExamSessionsListComponent } from './teacher/components/exam-sessions-list/exam-sessions-list.component';
import { ExamCreatorComponent } from './teacher/components/exam-creator/exam-creator.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { CoursesListComponent } from './teacher/components/courses-list/courses-list.component';

import { AuthGuard } from './guards/auth-guard.service';
import { RoleEnum } from './enums/role.enum';
import { ExamSessionComponent } from './teacher/components/exam-session/exam-session.component';
import { CourseCreatorComponent } from './teacher/components/course-creator/course-creator.component';
import { RegistrationComponent } from './components/registration/registration.component';

const appRoutes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'registration', component: RegistrationComponent },
  { path: 'login', component: LoginComponent },
  { path: 'profile', component: ProfileComponent },
  { path: 'about', component: AboutComponent },
  { path: 'student/exams-list', component: ExamsComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.User}},
  { path: 'student/exam', component: ExamComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.User}},
  { path: 'teacher/exams-list', component: ExamSessionsListComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.Admin}},
  { path: 'teacher/view-exam/:id', component: ExamSessionComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.Admin}},
  { path: 'teacher/exam-creator', component: ExamCreatorComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.Admin}},
  { path: 'teacher/courses-list', component: CoursesListComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.Admin}},
  { path: 'teacher/course-creator', component: CourseCreatorComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.Admin}},
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
