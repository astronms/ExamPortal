import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormGroupDirective, NgForm, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { Router } from '@angular/router';
import { UserModel } from 'src/app/models/user.model';

import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  public user: UserModel;
  passPattern = '(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}';
  matcher = new MyErrorStateMatcher();
  formGroup = new FormGroup({
    'password': new FormControl('', [Validators.required, Validators.pattern(this.passPattern)]),
    'password2': new FormControl('', [Validators.required]),
  }, { validators: passwordMatchValidator });

  constructor(
    public authService: AuthService,
    private router: Router
  ) {}

  ngOnInit()
  {
    this.user = this.authService.userValue;
  }

  changePassword()
  {
    if (this.formGroup.valid) {
      this.authService.changePassword(this.formGroup.get("password").value);
      this.router.navigate(["/profile"]);
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
