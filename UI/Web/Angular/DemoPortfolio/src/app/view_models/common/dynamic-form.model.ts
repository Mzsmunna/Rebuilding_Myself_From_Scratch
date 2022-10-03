export interface DynamicForm {

  Controls: DynamicFormControls[];
}

export interface DynamicFormControls {

  Name: string;
  Label: string;
  PlaceHolder: string;
  Value: string;
  Type: string;
  IsText?: boolean;
  IsTextarea?: boolean;
  IsNumber?: boolean;
  IsDate?: boolean;
  IsEmail?: boolean;
  IsPassword?: boolean;
  IsDropdown?: boolean;
  IsCheckBox?: boolean;
  IsRadio?: boolean;
  IsRequired?: boolean;
  IsRequiredTrue?: boolean;
  Min?: number | null;
  Max?: number | null;
  MinLength?: number | null;
  MaxLength?: number | null;
  Pattern?: string | null;
  IsNullValidator?: boolean | null;
  //Validators: DynamicFormValidators;
  Options?: DynamicFormDropdownOptions[];
  //required: boolean;

}

export interface DynamicFormValidators {

  Required?: boolean;
  RequiredTrue?: boolean;
  Pattern?: string | null;
  Min?: number | null;
  Max?: number | null;
  MinLength?: number | null;
  MaxLength?: number | null;
  NullValidator?: boolean | null;
}

export interface DynamicFormDropdownOptions {

  Key: string;
  Value: string;
  IsSelected?: boolean;
  //icon?: string;
}
