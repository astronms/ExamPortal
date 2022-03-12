import { HttpClientTestingModule, HttpTestingController } from "@angular/common/http/testing";

import { fakeAsync, TestBed, tick } from "@angular/core/testing";
import { JwtModule } from "@auth0/angular-jwt";
import { RoleEnum } from "../enums/role.enum";
import { UserModel } from "../models/user.model";
import { AuthService } from "./auth.service";

export function tokenGetter() {
    var user: UserModel = JSON.parse(localStorage.getItem("user"));
    return (user ? user.token : null);
}

describe('AuthService', () => {
    
    let baseUrl = "http://examportal.pl/";
    let httpTestingController: HttpTestingController;
    let authService: AuthService;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports: [
                JwtModule.forRoot({
                    config: {
                      tokenGetter: tokenGetter,
                      whitelistedDomains: [baseUrl],
                      blacklistedRoutes: []
                    }
                  }),
                HttpClientTestingModule
            ],
            providers: [
                { provide: 'BASE_URL', useValue: baseUrl }
            ]
        }).compileComponents();
        httpTestingController = TestBed.inject(HttpTestingController);
        authService = TestBed.inject(AuthService);

    });

    it('should return user after registration (HttpClient called once)', () => {
        const expectedUser: UserModel = {
            email: "blab@a.pl",
            password: "John12343",
            firstName: "John",
            lastName: "Doe",
            studentInfo: {index: 7777777}
        }
      
        authService.registerUser(expectedUser).subscribe(
            result => {
                expect(result).toEqual(expectedUser);
            },
            fail
        );

        const req = httpTestingController.expectOne(baseUrl + 'api/Account/register');
        req.flush(expectedUser, { status: 200, statusText: 'Success' });
      });

    it('should return error if backend fails to register user', () => {
        const expectedUser: UserModel = {
            email: "blab@a.pl",
            password: "John12343",
            firstName: "John",
            lastName: "Doe",
            studentInfo: {index: 7777777}
        };
        
        
        authService.registerUser(expectedUser).subscribe(
            result => 
                fail("Should fail with 404 error"),
            err => {
                expect(err).toEqual('Something bad happened; please try again later.');
            },
            fail
        );

        const req = httpTestingController.expectOne(baseUrl + 'api/Account/register');
        req.flush('404 error', { status: 404, statusText: 'Not Found' });
    });

    it('should return null if user not logged (authService.userRole)', () => {
       authService.logOut();
       expect(authService.userRole).toBeNull(); 
    });

    it('should return error if backend fails to login', () => {
        const expectedUser = {
            email: "blab@a.pl",
            password: "John12343",
        };
        
        
        authService.login(expectedUser).subscribe(
            result => 
                fail("Should fail with 404 error"),
            err => {
                expect(err).toEqual('Something bad happened; please try again later.');
            },
            fail
        );

        const req = httpTestingController.expectOne(baseUrl + 'api/Account/login');
        req.flush('401 Unauthorized', { status: 401, statusText: 'Unauthorized' });
    });

    it('should return true on successful login and save correct user object in LocalStorage', () => {
        const expectedUser = {
            email: "admin@admin.com",
            password: "John12343",
        };
        
        
        authService.login(expectedUser).subscribe(
            result => {
                expect(result).toBeDefined();
            },
            err => {
                fail("Shouldn't return error.");
            }
        );

        const exampleUser: UserModel = {
            email: "admin@admin.com",
            firstName: "Admin",
            lastName: "Admin",
            role: RoleEnum.Admin
        };

        const req = httpTestingController.expectOne(baseUrl + 'api/Account/login');
        req.flush(
            {
                "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJOYW1lIjoiYWRtaW5AYWRtaW4uY29tIiwiRmlyc3ROYW1lIjoiSm9obiIsIkxhc3ROYW1lIjoiRG9lIiwiUm9sZSI6IkFkbWluaXN0cmF0b3IiLCJleHAiOjE2NDI2MTc1MTUsImlzcyI6IkV4YW1Qb3J0YWxBUEkifQ.h1_5Yw2q5YIS01_vuQ1zhrBS8leflHlH935eeKBL5Dw"
            }, 
            { status: 202, statusText: 'Authorized' }
        );
        const reqUserInfo = httpTestingController.expectOne(baseUrl + 'api/Account/info');
        reqUserInfo.flush(exampleUser, { status: 202, statusText: 'Success' });

        let userString = localStorage.getItem("user");
        let user: UserModel = JSON.parse(userString);

        expect(userString).toBeDefined();
        expect(user.email).toEqual("admin@admin.com");
        expect(user.role).toEqual(RoleEnum.Admin);
    });

    it('should return false from isUserAuthenticated if token expired', () => {
        const expectedUser = {
            email: "admin@admin.com",
            password: "John12343",
        };
        
        
        authService.login(expectedUser).subscribe(
            result => {
                expect(result).toBeDefined();
            },
            err => {
                fail("Shouldn't return error.");
            }
        );

        const exampleUser: UserModel = {
            email: "admin@admin.com",
            firstName: "Admin",
            lastName: "Admin",
            role: RoleEnum.Admin
        }

        const req = httpTestingController.expectOne(baseUrl + 'api/Account/login');
        req.flush(
            {
                "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJOYW1lIjoiYWRtaW5AYWRtaW4uY29tIiwiRmlyc3ROYW1lIjoiSm9obiIsIkxhc3ROYW1lIjoiRG9lIiwiUm9sZSI6IkFkbWluaXN0cmF0b3IiLCJleHAiOjE2NDI2MTc1MTUsImlzcyI6IkV4YW1Qb3J0YWxBUEkifQ.h1_5Yw2q5YIS01_vuQ1zhrBS8leflHlH935eeKBL5Dw"
            }, 
            { status: 202, statusText: 'Authorized' }
        );
        const reqUserInfo = httpTestingController.expectOne(baseUrl + 'api/Account/info');
        reqUserInfo.flush(exampleUser, { status: 202, statusText: 'Success' });


        expect(authService.isUserAuthenticated()).toBeFalsy();
    });

    it('should return null if user not logged (authService.userRole)', () => {
        authService.logOut();
        expect(authService.userRole).toBeNull(); 
     });

    it('should return correct user role', () => {
        const expectedUser = {
            email: "admin@admin.com",
            password: "John12343",
        };
        
        
        authService.login(expectedUser).subscribe(
            result => {
                expect(result).toBeDefined();
            },
            err => {
                fail("Shouldn't return error.");
            }
        );

        const exampleUser: UserModel = {
            email: "admin@admin.com",
            firstName: "Admin",
            lastName: "Admin",
            role: RoleEnum.Admin
        }

        const req = httpTestingController.expectOne(baseUrl + 'api/Account/login');
        req.flush(
            {
                "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJOYW1lIjoiYWRtaW5AYWRtaW4uY29tIiwiRmlyc3ROYW1lIjoiSm9obiIsIkxhc3ROYW1lIjoiRG9lIiwiUm9sZSI6IkFkbWluaXN0cmF0b3IiLCJleHAiOjE2NDI2MTc1MTUsImlzcyI6IkV4YW1Qb3J0YWxBUEkifQ.h1_5Yw2q5YIS01_vuQ1zhrBS8leflHlH935eeKBL5Dw"
            }, 
            { status: 202, statusText: 'Authorized' }
        );
        const reqUserInfo = httpTestingController.expectOne(baseUrl + 'api/Account/info');
        reqUserInfo.flush(exampleUser, { status: 202, statusText: 'Success' });


        expect(authService.userRole).toEqual(RoleEnum.Admin); 
    });

    it('should logout the user', () => {
        const expectedUser = {
            email: "admin@admin.com",
            password: "John12343",
        };
        
        
        authService.login(expectedUser).subscribe(
            result => {
                expect(result).toBeDefined();
            },
            err => {
                fail("Shouldn't return error.");
            }
        );

        const exampleUser: UserModel = {
            email: "admin@admin.com",
            firstName: "Admin",
            lastName: "Admin",
            role: RoleEnum.Admin
        }

        const req = httpTestingController.expectOne(baseUrl + 'api/Account/login');
        req.flush(
            {
                "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJOYW1lIjoiYWRtaW5AYWRtaW4uY29tIiwiRmlyc3ROYW1lIjoiSm9obiIsIkxhc3ROYW1lIjoiRG9lIiwiUm9sZSI6IkFkbWluaXN0cmF0b3IiLCJleHAiOjE2NDI2MTc1MTUsImlzcyI6IkV4YW1Qb3J0YWxBUEkifQ.h1_5Yw2q5YIS01_vuQ1zhrBS8leflHlH935eeKBL5Dw"
            }, 
            { status: 202, statusText: 'Authorized' }
        );
        const reqUserInfo = httpTestingController.expectOne(baseUrl + 'api/Account/info');
        reqUserInfo.flush(exampleUser, { status: 202, statusText: 'Success' });


        authService.logOut();

        expect(authService.userValue).toBeNull();
        let userString = localStorage.getItem("user");
        expect(userString).toBeNull();
    });

      
});