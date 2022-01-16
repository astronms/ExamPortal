import { TestBed } from '@angular/core/testing'; // 1
import { NavMenuComponent } from './nav-menu.component';
import { RouterTestingModule } from '@angular/router/testing';
import { RoleEnum } from '../../enums/role.enum'
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { By } from 'protractor';


describe('NavMenuComponent', () => {
    let mockAuthService: jasmine.SpyObj<AuthService>;
    let router;

    beforeEach(() => {
        const spy = jasmine.createSpyObj('AuthService', ['isUserAuthenticated', 'userRole']);

        TestBed.configureTestingModule({
            imports: [ 
                RouterTestingModule.withRoutes([])
            ],
            declarations: [
                NavMenuComponent
            ],
            providers: [
                { provide: AuthService, useValue: spy }
            ]
        }).compileComponents();

        router = TestBed.inject(Router);
        mockAuthService = TestBed.inject(AuthService) as jasmine.SpyObj<AuthService>;
    });

    it('should create the NavMenuComponent', () => {
        mockAuthService.isUserAuthenticated.and.returnValue(false);
        //(mockAuthService as any).userRole = RoleEnum.Admin;
        const fixture = TestBed.createComponent(NavMenuComponent);
        const menu = fixture.debugElement.componentInstance;
        expect(menu).toBeTruthy();
    });

    it('should render home link', () => { 
        const fixture = TestBed.createComponent(NavMenuComponent);
        fixture.detectChanges();
        const menu = fixture.debugElement.nativeElement;
        expect(menu.querySelector('.logo-text').textContent).toContain('ExamPortal');
    });

    it('should show register and login if user not authenticated', () => {
        mockAuthService.isUserAuthenticated.and.returnValue(false);
        const fixture = TestBed.createComponent(NavMenuComponent);
        fixture.detectChanges();
        var htmlElements = document.getElementsByClassName("nav-link");
        var arr = Array.from(htmlElements);
        expect(arr.filter(item => item.textContent == "Rejestracja").length == 1).toBeTruthy();
        expect(arr.filter(item => item.textContent == "Logowanie").length == 1).toBeTruthy();
    });

    it('should not show register and login if user authenticated', () => {
        mockAuthService.isUserAuthenticated.and.returnValue(true);
        (mockAuthService as any).userRole = RoleEnum.Admin;
        const fixture = TestBed.createComponent(NavMenuComponent);
        fixture.detectChanges();
        var htmlElements = document.getElementsByClassName("nav-link");
        var arr = Array.from(htmlElements);
        expect(arr.filter(item => item.textContent == "Rejestracja").length == 0).toBeTruthy();
        expect(arr.filter(item => item.textContent == "Logowanie").length == 0).toBeTruthy();
    });

    it('should show exams if student authenticated', () => {
        mockAuthService.isUserAuthenticated.and.returnValue(true);
        (mockAuthService as any).userRole = RoleEnum.User;
        const fixture = TestBed.createComponent(NavMenuComponent);
        fixture.detectChanges();
        var htmlElements = document.getElementsByClassName("nav-link");
        var arr = Array.from(htmlElements);
        expect(arr.filter(item => item.textContent == "Egzaminy").length == 1).toBeTruthy();
    });

    it('should not show courses if student authenticated', () => {
        mockAuthService.isUserAuthenticated.and.returnValue(true);
        (mockAuthService as any).userRole = RoleEnum.User;
        const fixture = TestBed.createComponent(NavMenuComponent);
        fixture.detectChanges();
        var htmlElements = document.getElementsByClassName("nav-link");
        var arr = Array.from(htmlElements);
        expect(arr.filter(item => item.textContent == "Kursy").length == 0).toBeTruthy();
    });

    it('should show courses if teacher authenticated', () => {
        mockAuthService.isUserAuthenticated.and.returnValue(true);
        (mockAuthService as any).userRole = RoleEnum.Admin;
        const fixture = TestBed.createComponent(NavMenuComponent);
        fixture.detectChanges();
        var htmlElements = document.getElementsByClassName("nav-link");
        var arr = Array.from(htmlElements);
        expect(arr.filter(item => item.textContent == "Kursy").length == 1).toBeTruthy();
    });

    it('should call isUserAuthenticated', () => {
        mockAuthService.isUserAuthenticated.and.returnValue(true);
        (mockAuthService as any).userRole = RoleEnum.Admin;
        const fixture = TestBed.createComponent(NavMenuComponent);
        fixture.detectChanges();
        expect(mockAuthService.isUserAuthenticated).toHaveBeenCalled();
    });
});