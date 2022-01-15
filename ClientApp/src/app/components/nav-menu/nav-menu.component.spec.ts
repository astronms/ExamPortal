import { TestBed } from '@angular/core/testing'; // 1
import { NavMenuComponent } from './nav-menu.component';
import { RouterTestingModule } from '@angular/router/testing';
import { RoleEnum } from '../../enums/role.enum'
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';


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
        mockAuthService.isUserAuthenticated.and.returnValue(true);
        (mockAuthService as any).userRole = RoleEnum.Admin;
        const fixture = TestBed.createComponent(NavMenuComponent);
        const app = fixture.debugElement.componentInstance;
        expect(app).toBeTruthy();
    });
});