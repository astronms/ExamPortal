import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { AuthGuard } from './guards/auth-guard.service';
import { RoleEnum } from './enums/role.enum';

import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { ProfileComponent } from './components/profile/profile.component';
import { AboutComponent } from './components/about/about.component';
import { ExamsComponent } from './student/components/exams/exams.component';
import { ExamComponent } from './student/components/exam/exam.component';
import { ExamSessionsListComponent } from './teacher/components/exam-sessions-list/exam-sessions-list.component';
import { ExamSessionCreatorComponent } from './teacher/components/exam-session-creator/exam-session-creator.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { CoursesListComponent } from './teacher/components/courses-list/courses-list.component';
import { ExamSessionComponent } from './teacher/components/exam-session/exam-session.component';
import { CourseCreatorComponent } from './teacher/components/course-creator/course-creator.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { CourseComponent } from './teacher/components/course/course.component';
import { CourseEditComponent } from './teacher/components/course-edit/course-edit.component';
import { CourseDeleteComponent } from './teacher/components/course-delete/course-delete.component';
import { ExamSessionDeleteComponent } from './teacher/components/exam-session-delete/exam-session-delete.component';
import { ExamSessionEditComponent } from './teacher/components/exam-session-edit/exam-session-edit.component';
import { ExamSessionResultsListComponent } from './teacher/components/exam-session-results-list/exam-session-results-list.component';
import { TeacherCreatorComponent } from './admin/components/teacher-creator/teacher-creator.component';
import { ExamSessionResultComponent } from './teacher/components/exam-session-result/exam-session-result.component';
import { ExamsResultsListComponent } from './student/components/exams-results-list/exams-results-list.component';
import { ExamResultComponent } from './student/components/exam-result/exam-result.component';
import { ExamSessionStudentResultComponent } from './teacher/components/exam-session-student-result/exam-session-student-result.component';

const appRoutes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'registration', component: RegistrationComponent },
  { path: 'login', component: LoginComponent },
  { path: 'about', component: AboutComponent },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },
  { path: 'student/exams-list', component: ExamsComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.User}},
  { path: 'student/exams-results', component: ExamsResultsListComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.User}},
  { path: 'student/exam-result/:id', component: ExamResultComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.User}},
  { path: 'student/exam/:id', component: ExamComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.User}},
  { path: 'teacher/exams-list', component: ExamSessionsListComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.Admin}},
  { path: 'teacher/exam-creator', component: ExamSessionCreatorComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.Admin}},
  { path: 'teacher/view-exam/:id', component: ExamSessionComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.Admin}},
  { path: 'teacher/edit-exam/:id', component: ExamSessionEditComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.Admin}},
  { path: 'teacher/delete-exam/:id', component: ExamSessionDeleteComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.Admin}},
  { path: 'teacher/courses-list', component: CoursesListComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.Admin}},
  { path: 'teacher/course-creator', component: CourseCreatorComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.Admin}},
  { path: 'teacher/view-course/:id', component: CourseComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.Admin}},
  { path: 'teacher/edit-course/:id', component: CourseEditComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.Admin}},
  { path: 'teacher/delete-course/:id', component: CourseDeleteComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.Admin}},
  { path: 'teacher/results-list', component: ExamSessionResultsListComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.Admin}},
  { path: 'teacher/exam-result/:id', component: ExamSessionResultComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.Admin}},
  { path: 'teacher/exam-student-result/:id/:userId', component: ExamSessionStudentResultComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.Admin}},
  { path: 'admin/teacher-create', component: TeacherCreatorComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.SuperAdmin}},
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
