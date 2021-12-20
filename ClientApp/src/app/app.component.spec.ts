// app.component.spec.ts
import { Component } from '@angular/core';
import { TestBed, async } from '@angular/core/testing'; // 1
import { AppComponent } from './app.component';
import { RouterTestingModule } from '@angular/router/testing';


describe('AppComponent', () => { // 2
    beforeEach(async(() => { // 3
        TestBed.configureTestingModule({
            imports: [ RouterTestingModule ],
            declarations: [
                AppComponent,
                MockNavComponent
            ],
        }).compileComponents();
    }));

    it('should create the app', () => { // 4
        const fixture = TestBed.createComponent(AppComponent);
        const app = fixture.debugElement.componentInstance;
        expect(app).toBeTruthy();
    });

    it(`should have as title 'angular-component-testing'`, () => {  //5
        const fixture = TestBed.createComponent(AppComponent);
        const app = fixture.debugElement.componentInstance;
        expect(app.title).toEqual('ExamPortal');
    });

    /*it('should render title in a h1 tag', () => { //6
        const fixture = TestBed.createComponent(AppComponent);
        fixture.detectChanges();
        const compiled = fixture.debugElement.nativeElement;
        expect(compiled.querySelector('h1').textContent).toContain('Welcome to angular-component-testing!');
    });*/
});

@Component({
    selector: 'app-nav-menu',
    template: ''
  })
  class MockNavComponent {
  }