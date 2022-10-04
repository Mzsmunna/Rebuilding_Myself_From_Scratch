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
  IsRange?: boolean;
  IsRequired?: boolean;
  IsRequiredTrue?: boolean;
  Min?: number;
  Max?: number;
  MinLength?: number;
  MaxLength?: number;
  Pattern?: string;
  IsNullValidator?: boolean;
  Options?: DynamicFormDropdownOptions[];
}

export interface DynamicFormDropdownOptions {

  Key: string;
  Value: string;
  IsSelected?: boolean;
  IsMultiSelect?: boolean;
  //icon?: string;
}
