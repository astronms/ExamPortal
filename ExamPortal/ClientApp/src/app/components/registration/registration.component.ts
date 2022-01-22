import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormGroupDirective, NgForm, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { Router } from '@angular/router';

import { StudentInfoModel, UserModel } from 'src/app/models/user.model';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})

export class RegistrationComponent implements OnInit {

  passPattern = '(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}';
  indexPattern = '([0-9]){5,8}';

  formGroup = new FormGroup({
    'email': new FormControl('', [Validators.required, Validators.email]),
    'firstName': new FormControl('', [Validators.required]),
    'lastName': new FormControl('', [Validators.required]),
    'index_number': new FormControl('', [Validators.required, Validators.pattern(this.indexPattern)]),
    'password': new FormControl('', [Validators.required, Validators.pattern(this.passPattern)]),
    'password2': new FormControl('', [Validators.required]),
  }, { validators: passwordMatchValidator });

  matcher = new MyErrorStateMatcher();

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  onSubmit()
  {
    if (this.formGroup.valid) {

      var registerUser: UserModel = {
        id: null,
        email: this.formGroup.get("email").value,
        password: this.formGroup.get("password").value,
        firstName: this.formGroup.get("firstName").value,
        lastName: this.formGroup.get("lastName").value,
        studentInfo: <StudentInfoModel>{index: this.formGroup.get("index_number").value}
      };

      this.authService.registerUser(registerUser)
        .subscribe(result => {
          this.authService.login({
            email: this.formGroup.get("email").value,
            password: this.formGroup.get("password").value
          }).subscribe(result => {
            this.router.navigate(["/"]);
          })
        }
      );
    }
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