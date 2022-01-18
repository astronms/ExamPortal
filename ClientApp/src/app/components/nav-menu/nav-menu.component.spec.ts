import { TestBed } from '@angular/core/testing'; // 1
import { NavMenuComponent } from './nav-menu.component';
import { RouterTestingModule } from '@angular/router/testing';
import { RoleEnum } from '../../enums/role.enum'
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { By } from '@angular/platform-browser';


describe('NavMenuComponent', () => {
    let mockAuthService: jasmine.SpyObj<AuthService>;
    let router;

    beforeEach(() => {
        const spy = jasmine.createSpyObj('AuthService', ['isUserAuthenticated', 'userRole', 'logOut']);

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

        mockAuthService = TestBed.inject(AuthService) as jasmine.SpyObj<AuthService>;
        router = TestBed.inject(Router);
    });

    it('should create the NavMenuComponent', () => {
        mockAuthService.isUserAuthenticated.and.returnValue(false);
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
        let htmlElements = document.getElementsByClassName("nav-link");
        let arr = Array.from(htmlElements);
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

    it('should assign href attribute to "O Projekcie" element', () => {
        mockAuthService.isUserAuthenticated.and.returnValue(false);
        const fixture = TestBed.createComponent(NavMenuComponent);
        fixture.detectChanges();
        let menu_item;
        fixture.debugElement.queryAll(By.css('.nav-link'))
            .map(el => {
                if(el.nativeElement.innerHTML == "O projekcie")
                    menu_item = el;
            }
        );
        expect(menu_item.nativeElement.getAttribute('href')).toEqual('/about');
    });

    it('should call authService.logOut and redirect if "Wyloguj" clicked', () => {
        mockAuthService.isUserAuthenticated.and.returnValue(true);
        (mockAuthService as any).userRole = RoleEnum.Admin;
        var routerSpy = spyOn(router, 'navigate');
        const fixture = TestBed.createComponent(NavMenuComponent);
        fixture.detectChanges();
        let menu_item;
        fixture.debugElement.queryAll(By.css('.nav-link'))
            .map(el => {
                if(el.nativeElement.innerHTML == "Wyloguj")
                    menu_item = el;
            }
        );

        menu_item.nativeElement.click();
        expect(mockAuthService.logOut).toHaveBeenCalled();
        expect(routerSpy).toHaveBeenCalledWith(["/"]);

    });

});