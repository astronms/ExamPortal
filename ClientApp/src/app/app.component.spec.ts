import { Component } from '@angular/core';
import { TestBed } from '@angular/core/testing'; // 1
import { AppComponent } from './app.component';
import { RouterTestingModule } from '@angular/router/testing';


describe('AppComponent', () => { 
    beforeEach(() => { 
        TestBed.configureTestingModule({
            imports: [ RouterTestingModule ],
            declarations: [
                AppComponent,
                MockNavComponent
            ],
        }).compileComponents();
    });

    it('should create the app', () => {
        const fixture = TestBed.createComponent(AppComponent);
        const app = fixture.debugElement.componentInstance;
        expect(app).toBeTruthy();
    });

    it(`should have as title 'angular-component-testing'`, () => {
        const fixture = TestBed.createComponent(AppComponent);
        const app = fixture.debugElement.componentInstance;
        expect(app.title).toEqual('ExamPortal');
    });
});

@Component({
    selector: 'app-nav-menu',
    template: ''
  })
  class MockNavComponent {
  }