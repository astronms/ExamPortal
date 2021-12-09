import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { JwtModule } from "@auth0/angular-jwt";
import localPl from '@angular/common/locales/pl';
import { registerLocaleData } from '@angular/common';

import { StudentModule } from './student/student.module';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { ExamsComponent } from './student/components/exams/exams.component';
import { ExamComponent } from './student/components/exam/exam.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';

import { AuthService } from './services/auth.service';
import { AuthGuard } from './guards/auth-guard.service';
import { UserModel} from './models/user.model'
import { RoleEnum } from './enums/role.enum';


export function tokenGetter() {
  var user: UserModel = JSON.parse(localStorage.getItem("user"));
  return (user ? user.token : null);
}

registerLocaleData(localPl);

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    StudentModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'exams', component: ExamsComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.User}},
      { path: 'exam', component: ExamComponent, canActivate: [AuthGuard], data: {roles: RoleEnum.User}},
      { path: '**', component: PageNotFoundComponent }
    ]),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:5000"],
        blacklistedRoutes: []
      }
    })
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'pl' },
    AuthService,
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
