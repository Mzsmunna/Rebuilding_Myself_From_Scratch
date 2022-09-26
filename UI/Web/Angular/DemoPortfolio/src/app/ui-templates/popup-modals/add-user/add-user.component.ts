import { formatDate } from '@angular/common';
import { Component, ElementRef, Input, OnInit, SimpleChange, SimpleChanges, ViewChild } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { AuthService } from '../../../services/auth/auth.service';
import { UserService } from '../../../services/features/user/user.service';
import { User } from '../../../view_models/auth/user.model';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

  previousUser = {} as User;

  @Input() currentProfile: User;
  @Input() classNames: string;
  @Input() buttonName: string;

  @ViewChild('closeModal', { static: false }) closeModal: ElementRef<HTMLButtonElement>;

  constructor(private authService: AuthService, private userService: UserService ) {

    this.previousUser = {} as User;
    this.currentProfile = {} as User;
    this.classNames = "btn btn-primary";
    this.buttonName = "Add User";

    this.ResetUser();

    this.closeModal = {} as ElementRef;
  }

  ngOnInit(): void {

    this.userService.selectedProfile$.subscribe(result => {

      console.log("Add modal user:", result);

      if (!result.Id) {

        this.buttonName = "Add User";
        this.previousUser = this.currentProfile;

        this.currentProfile = result;
        this.ResetUser();

      } else {

        this.previousUser = result;
      }

    });
  }

  ngOnChanges(changes: SimpleChanges) {

    console.log(`ngOnChanges: app-add-user`);

    if (changes) {

      console.log(changes);

      const currentItem: SimpleChange = changes["data"];
    }
  }

  OnModalClose() {

    console.log("OnModal preserve user: ", this.previousUser);

    if (this.previousUser.Id) {

      this.currentProfile = this.previousUser;
      this.buttonName = "Edit User";
    }    
  }

  SaveUser(userForm: FormGroup) {

    if (userForm.valid) {

      if (this.currentProfile.Id)
        this.currentProfile.ModifiedBy = this.authService.GetCurrentUserId();
      else
        this.currentProfile.CreatedBy = this.authService.GetCurrentUserId();

      this.userService.SaveUser(this.currentProfile).subscribe(result => {

        console.log("saved user: ", result);

        if (result) {

          this.closeModal.nativeElement.click();

          if (this.currentProfile.Id) {


          } else {

            userForm.reset();
            this.ResetUser();
          }

        } else {

          console.log("something went wrong while saving the user: ", this.currentProfile);
        }

      });

    } else {

      console.log("Invalid user info : ", this.currentProfile);
    }
  }

  ResetUser() {

    this.currentProfile = {} as User;
    this.currentProfile.Gender = "male";
    this.currentProfile.Role = "user";
    this.currentProfile.Department = "";
    this.currentProfile.Position = "";
    this.currentProfile.IsActive = true;
  }

  FormateDate(date: Date | null) {

    if (date) {

      return formatDate(date, "yyyy-MM-dd", "en");
    }
    else
      return date;
  }

}
