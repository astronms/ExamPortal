import { TestBed } from '@angular/core/testing'; // 1
import { HomeComponent } from './home.component';
import { RouterTestingModule } from '@angular/router/testing';


describe('HomeComponent', () => {
    beforeEach(() => { 
        TestBed.configureTestingModule({
            imports: [ RouterTestingModule ],
            declarations: [
                HomeComponent
            ],
        }).compileComponents();
    });

    it('should create the HomeComponent', () => { 
        const fixture = TestBed.createComponent(HomeComponent);
        const app = fixture.debugElement.componentInstance;
        expect(app).toBeTruthy();
    });

    it('should render title in a h1 tag', () => { 
        const fixture = TestBed.createComponent(HomeComponent);
        fixture.detectChanges();
        const compiled = fixture.debugElement.nativeElement;
        expect(compiled.querySelector('h1').textContent).toContain('ExamPortal');
    });

    it('should render short description in a h2 tag', () => { 
        const fixture = TestBed.createComponent(HomeComponent);
        fixture.detectChanges();
        const compiled = fixture.debugElement.nativeElement;
        expect(compiled.querySelector('h2').textContent).toContain('Egzaminacyjny Politechniki Gdańskiej');
    });
});