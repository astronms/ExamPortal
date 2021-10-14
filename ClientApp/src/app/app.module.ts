import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { JwtModule } from "@auth0/angular-jwt";
import localPl from '@angular/common/locales/pl';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { ExamsComponent } from './components/exams/exams.component';

import { AuthService } from './services/auth.service';
import { ExamsService } from './services/exams.service';
import { ExamFactoryService } from './services/exam-factory.service';
import { SyncExamService } from './services/sync-exam.service';

import { AuthGuard } from './guards/auth-guard.service';
import { ExamComponent } from './components/exam/exam.component';
import { registerLocaleData } from '@angular/common';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

registerLocaleData(localPl);

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    ExamsComponent,
    ExamComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'exams', component: ExamsComponent, canActivate: [AuthGuard]},
      { path: 'exam', component: ExamComponent, canActivate: [AuthGuard]},
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
    ExamsService,
    ExamFactoryService,
    SyncExamService,
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
