import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, FormGroupDirective, NgForm, NG_VALIDATORS, NG_VALUE_ACCESSOR, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { ErrorStateMatcher, ShowOnDirtyErrorStateMatcher } from '@angular/material/core';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})

export class RegistrationComponent implements OnInit {

  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  /*passwordGroup = new FormGroup({
    'password': new FormControl('', [Validators.required]),
    'password2': new FormControl('', [Validators.required])
  }, { validators: passwordMatchValidator });*/
  passPattern = '^(?=.[a-z])(?=.[A-Z])(?=.\d)(?=.[#$^+=!*()@%&]).{8,}$';

  formGroup = new FormGroup({
    'email': new FormControl('', [Validators.required, Validators.email]),
    'password': new FormControl('', [Validators.required, Validators.pattern(this.passPattern)]),
    'password2': new FormControl('', [Validators.required]),
  }, { validators: passwordMatchValidator });


  matcher = new MyErrorStateMatcher();
  

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void {
  }

  test()
  {
    //console.log(this.formGroup);
    console.log(this.formGroup.get("password2"));
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