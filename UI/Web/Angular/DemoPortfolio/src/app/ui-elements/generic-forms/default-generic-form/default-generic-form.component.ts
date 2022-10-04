import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DynamicForm } from '../../../view_models/common/dynamic-form.model';

@Component({
  selector: 'app-default-generic-form',
  templateUrl: './default-generic-form.component.html',
  styleUrls: ['./default-generic-form.component.css']
})
export class DefaultGenericFormComponent implements OnInit {

  dynamicFormModel: DynamicForm;

  dynamicFormGroup: FormGroup;

  constructor(private formBuilder: FormBuilder) {

    this.dynamicFormGroup = this.formBuilder.group({});

    //this.dynamicForm = {} as DynamicForm;
    this.dynamicFormModel = {

      Controls: [
        {
          Name: "FullName",
          Label: "Full Name",
          PlaceHolder: "Full Name",
          Value: "",
          Type: "text",
          IsText: true,
          //IsTextarea?: boolean,
          //IsEmail?: boolean,
          //IsPassword?: boolean,
          //IsDropdown?: boolean,
          //IsCheck?: boolean,
          //IsRadio?: boolean,
          IsRequired: true,
          MinLength: 10,
          MaxLength: 20,
          Pattern: ""
          //Validators: {
          //  IsRequired: true,
          //  MinLength: 10,
          //  MaxLength: 20,
          //  Pattern: "",           
          //}

        },
        {
          Name: "Gender",
          Label: "Gender",
          PlaceHolder: "",
          Value: "",
          Type: "select",
          IsDropdown: true,
          IsRequired: false,
          Pattern: "",
          Options: [
            {
              Key: "Male",
              Value: "male",
              IsSelected: true
            },
            {
              Key: "Female",
              Value: "female",
              IsSelected: false
            },
            {
              Key: "Other",
              Value: "other",
              IsSelected: false
            }
          ]
        },
        {
          Name: "Email",
          Label: "Email",
          PlaceHolder: "Email",
          Value: "",
          Type: "email",
          IsEmail: true,
          IsRequired: true,
          Pattern: "",

        },
        {
          Name: "PhoneOrMobile",
          Label: "",
          PlaceHolder: "",
          Value: "",
          Type: "select",
          IsRadio: true, //IsCheckBox: true,
          IsRequired: false,
          Pattern: "",
          Options: [
            {
              Key: "Phone",
              Value: "phone",
              IsSelected: true
            },
            {
              Key: "Mobile",
              Value: "mobile",
              IsSelected: false
            }
          ]

        },
        {
          Name: "ContactNumber",
          Label: "Contact Number",
          PlaceHolder: "",
          Value: "",
          Type: "text",
          IsText: true,
          IsRequired: false,
          Pattern: "(([+][(]?[0-9]{1,3}[)]?)|([(]?[0-9]{4}[)]?))\s*[)]?[-\s\.]?[(]?[0-9]{1,3}[)]?([-\s\.]?[0-9]{3})([-\s\.]?[0-9]{3,4})",
        },
        {
          Name: "Message",
          Label: "Message",
          PlaceHolder: "",
          Value: "",
          Type: "text", //Type: "textarea",
          IsText: true, //IsTextarea: true,
          IsRequired: true,
          MinLength: 10,
          MaxLength: 50,
          Pattern: ""
        }
      ]
    };
  }

  ngOnInit(): void {

    this.CreateDynamicForm();
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
