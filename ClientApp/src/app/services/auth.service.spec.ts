import { HttpClientTestingModule, HttpTestingController } from "@angular/common/http/testing";

import { TestBed } from "@angular/core/testing";
import { JwtModule } from "@auth0/angular-jwt";
import { AuthUserModel } from "../models/auth-user.model";
import { UserModel } from "../models/user.model";
import { AuthService } from "./auth.service";

export function tokenGetter() {
    var user: AuthUserModel = JSON.parse(localStorage.getItem("user"));
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
        const expectedUser: UserModel = 
            {
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

      
});