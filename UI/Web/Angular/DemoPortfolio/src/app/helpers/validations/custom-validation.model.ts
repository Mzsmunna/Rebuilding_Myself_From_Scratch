import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export class CustomValidation {

  static passwordMatchValidate: ValidatorFn = (control: AbstractControl): ValidationErrors | null => {

    const password = control.get('Password');
    const confirmPassword = control.get('ConfirmPassword');

    if (password?.value !== confirmPassword?.value) {

      confirmPassword?.setErrors({ notmatched: true }); //matching: true
      return { notmatched: true };

    } else {

      return null;
    }
  }
}
