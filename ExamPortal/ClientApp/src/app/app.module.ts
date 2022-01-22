import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from "@auth0/angular-jwt";
import localPl from '@angular/common/locales/pl';
import { registerLocaleData } from '@angular/common';

import { StudentModule } from './student/student.module';
import { AppRoutingModule } from './app-routing.module';
import { TeacherModule } from './teacher/teacher.module';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { AboutComponent } from './components/about/about.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { ProfileComponent } from './components/profile/profile.component'
import { RegistrationComponent } from './components/registration/registration.component'

import { AuthService } from './services/auth.service';
import { AuthGuard } from './guards/auth-guard.service';
import { AuthUserModel } from './models/auth-user.model';
import { SharedModule } from './shared/shared.module';


export function tokenGetter() {
  var user: AuthUserModel = JSON.parse(localStorage.getItem("user"));
  return (user ? user.token : null);
}

registerLocaleData(localPl);

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    PageNotFoundComponent,
    ProfileComponent, 
    AboutComponent, 
    RegistrationComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    StudentModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:5000"],
        blacklistedRoutes: []
      }
    }),
    TeacherModule,
    SharedModule
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'pl' },
    AuthService,
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }