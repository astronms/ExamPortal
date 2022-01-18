import { TestBed } from '@angular/core/testing'; // 1
import { LoginComponent } from './login.component';
import { RouterTestingModule } from '@angular/router/testing';
import { RoleEnum } from '../../enums/role.enum'
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { By } from '@angular/platform-browser';
import { FormsModule, NgForm } from '@angular/forms';
import { Observable, throwError } from 'rxjs';


describe('LoginComponent', () => {
    let mockAuthService: jasmine.SpyObj<AuthService>;
    let router;
    let fixture;

    beforeEach(() => {
        const spy = jasmine.createSpyObj('AuthService', ['login']);

        TestBed.configureTestingModule({
            imports: [ 
                RouterTestingModule.withRoutes([]),
                FormsModule
            ],
            declarations: [
                LoginComponent
            ],
            providers: [
                { provide: AuthService, useValue: spy },
            ]
        }).compileComponents();

        mockAuthService = TestBed.inject(AuthService) as jasmine.SpyObj<AuthService>;
        router = TestBed.inject(Router);

        fixture = TestBed.createComponent(LoginComponent);
        fixture.detectChanges();
    });

    it('should create the LoginComponent', () => {
        const login = fixture.debugElement.componentInstance;
        expect(login).toBeTruthy();
    });

    it('should call login authService method after login press', () => {
        const mockResponse = new Observable<boolean>( observer => {
            observer.next(true);
            observer.complete();
          })
        mockAuthService.login.and.returnValue(mockResponse); 
        
        const loginBtn = fixture.debugElement.nativeElement.querySelector(".btn-lg");
        loginBtn.click();
        
        expect(mockAuthService.login).toHaveBeenCalled();
    });

    it('should redirect to home after successfully login', () => {
        const mockResponse = new Observable<boolean>( observer => {
            observer.next(true);
            observer.complete();
          })
        mockAuthService.login.and.returnValue(mockResponse);
        var routerSpy = spyOn(router, 'navigate');
        
        const loginBtn = fixture.debugElement.nativeElement.querySelector(".btn-lg");
        loginBtn.click();
        
        expect(routerSpy).toHaveBeenCalledWith(["/"]);
    });

    it('should not redirect to home if failed login', () => {
        const mockResponse = new Observable<boolean>( observer => {
            observer.next(false);
            observer.complete();
          })
        mockAuthService.login.and.returnValue(mockResponse);
        var routerSpy = spyOn(router, 'navigate');
        
        const loginBtn = fixture.debugElement.nativeElement.querySelector(".btn-lg");
        loginBtn.click();
        
        expect(routerSpy).not.toHaveBeenCalled();
    });

    it('should show information about failure in login', () => {
        const mockResponse = new Observable<boolean>( observer => {
            observer.next(false);
            observer.complete();
          })
        mockAuthService.login.and.returnValue(mockResponse);
        
        const loginBtn = fixture.debugElement.nativeElement.querySelector(".btn-lg");
        loginBtn.click();
        
        expect(fixture.componentInstance.invalidLogin).toBeTruthy();
    });

    it('should show information about failure in login (service throws error)', () => {
        const mockResponse = throwError('Something bad happened; please try again later.');
        mockAuthService.login.and.returnValue(mockResponse);
        
        const loginBtn = fixture.debugElement.nativeElement.querySelector(".btn-lg");
        loginBtn.click();
        
        expect(fixture.componentInstance.invalidLogin).toBeTruthy();
    });

});