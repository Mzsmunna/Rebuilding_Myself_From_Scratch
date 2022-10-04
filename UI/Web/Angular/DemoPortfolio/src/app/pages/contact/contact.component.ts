import { Component, OnInit } from '@angular/core';
import { DynamicForm } from '../../view_models/common/dynamic-form.model';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})
export class ContactComponent implements OnInit {

  contactFormModel: DynamicForm;

  constructor() {

    this.contactFormModel = {

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
          //IsRange?: boolean,
          IsRequired: true,
          MinLength: 10,
          MaxLength: 20,
          Pattern: ""
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

  }

}
