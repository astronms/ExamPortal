import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormGroupDirective, NgForm, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { Router } from '@angular/router';
import { UserModel } from 'src/app/models/user.model';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-teacher-creator',
  templateUrl: './teacher-creator.component.html',
  styleUrls: ['./teacher-creator.component.css']
})
export class TeacherCreatorComponent {

  registrationSuccess = false;
  registrationFailed = false;

  passPattern = '(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}';
  matcher = new MyErrorStateMatcher();

  formGroup = new FormGroup({
    'email': new FormControl('', [Validators.required, Validators.email]),
    'firstName': new FormControl('', [Validators.required]),
    'lastName': new FormControl('', [Validators.required]),
    'password': new FormControl('', [Validators.required, Validators.pattern(this.passPattern)]),
    'password2': new FormControl('', [Validators.required]),
  }, { validators: passwordMatchValidator });

  constructor(
    private router: Router,
    private authService: AuthService
  ) { }

  onSubmit()
  {
    if (this.formGroup.valid) {

      var registerUser: UserModel = {
        id: null,
        email: this.formGroup.get("email").value,
        password: this.formGroup.get("password").value,
        firstName: this.formGroup.get("firstName").value,
        lastName: this.formGroup.get("lastName").value,
      };

      this.authService.registerTeacher(registerUser)
        .subscribe(() => {
          this.resetForm();
          this.registrationSuccess = true;
          this.registrationFailed = false;
        }, () => {
          this.registrationFailed = true;
          this.registrationSuccess = false;
        }
      );
    }
  }

  private resetForm() {
    this.formGroup.reset();

    Object.keys(this.formGroup.controls).forEach(key => {
      this.formGroup.get(key).setErrors(null) ;
    });
  }
  
}

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}

export const passwordMatchValidator: ValidatorFn = (formGroup: FormGroup): ValidationErrors | null => {
  if(formGroup.get('password').value != formGroup.get('password2').value)
    formGroup.get('password2').setErrors({passwordMismatch: true});
  return null;
}