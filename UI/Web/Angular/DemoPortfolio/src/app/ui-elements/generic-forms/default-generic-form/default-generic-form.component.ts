import { Component, Input, OnInit, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DynamicForm } from '../../../view_models/common/dynamic-form.model';

@Component({
  selector: 'app-default-generic-form',
  templateUrl: './default-generic-form.component.html',
  styleUrls: ['./default-generic-form.component.css']
})
export class DefaultGenericFormComponent implements OnInit {

  @Input() dynamicFormModel: DynamicForm;

  dynamicFormGroup: FormGroup;

  constructor(private formBuilder: FormBuilder) {

    this.dynamicFormGroup = this.formBuilder.group({});

    this.dynamicFormModel = {} as DynamicForm;
  }

  ngOnInit(): void {

    this.CreateDynamicForm();
  }

  ngOnChanges(changes: SimpleChanges) {

    console.log(`ngOnChanges: default-generic-form`, changes);

    if (!changes["dynamicFormModel"].firstChange) {

      this.CreateDynamicForm();
    }
  }

  CreateDynamicForm() {

    for (const control of this.dynamicFormModel.Controls) {

      const validatorsToAdd = [];
      let value = control.Value;

      if (control.IsRequired) {

        validatorsToAdd.push(Validators.required);
      }

      if (control.IsRequiredTrue) {

        validatorsToAdd.push(Validators.requiredTrue);
      }

      if (control.IsEmail) {

        validatorsToAdd.push(Validators.email);
      }

      if (control.Min) {

        validatorsToAdd.push(Validators.min(control.Min));
      }

      if (control.MinLength) {

        validatorsToAdd.push(Validators.minLength(control.MinLength));
      }

      if (control.Max) {

        validatorsToAdd.push(Validators.max(control.Max));
      }

      if (control.MaxLength) {

        validatorsToAdd.push(Validators.maxLength(control.MaxLength));
      }

      if (control.Pattern) {

        validatorsToAdd.push(Validators.pattern(control.Pattern));
      }

      if (control.IsNullValidator) {

        validatorsToAdd.push(Validators.nullValidator);
      }

      if (control.Options) {

        for (const option of control.Options) {

          if (option.IsSelected)
            value = option.Value;
        }

      }

      this.dynamicFormGroup.addControl(

        control.Name,
        this.formBuilder.control(value, validatorsToAdd)
      );

    }

    console.log("Dynamic Form:", this.dynamicFormGroup);
  }

  OnSubmit(isValid: boolean) {

    console.log("Dynamic Form submitted:", this.dynamicFormGroup);
  }

}
