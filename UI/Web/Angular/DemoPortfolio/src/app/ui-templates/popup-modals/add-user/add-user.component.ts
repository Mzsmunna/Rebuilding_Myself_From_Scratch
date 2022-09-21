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

  public newUser: User;

  @Input() loggedUser: User;
  @ViewChild('closeModal', { static: false }) closeModal: ElementRef<HTMLButtonElement>;

  constructor(private authService: AuthService, private userService: UserService ) {

    this.loggedUser = {} as User;
    this.newUser = {} as User;
    this.newUser.Gender = "male";
    this.newUser.Role = "user";

    this.closeModal = {} as ElementRef;
  }

  ngOnInit(): void {

  }

  ngOnChanges(changes: SimpleChanges) {

    console.log(`ngOnChanges: app-add-user`);

    if (changes) {

      console.log(changes);
      //  console.log("app-ng-smart-table : updated data");
      //  console.log(changes['data']['currentValue']);
      //  this.data = changes['data']['currentValue'];
      //console.log(this.data);

      const currentItem: SimpleChange = changes["data"];
      ///console.log('prev value: ', currentItem.previousValue);
      //console.log('got item: ', currentItem.currentValue);
      //this.loggedUser = changes['data']['currentValue'];
    }
  }

  SaveUser(userForm: FormGroup) {

    if (userForm.valid) {

      if (this.newUser.Id)
        this.newUser.ModifiedBy = this.authService.GetCurrentUserId();
      else
        this.newUser.CreatedBy = this.authService.GetCurrentUserId();

      this.authService.Register(this.newUser).subscribe(result => {

        console.log("saved user: ", result);

        if (result) {

          this.closeModal.nativeElement.click();

          userForm.reset();
          this.newUser = {} as User;
          this.newUser.Gender = "male";
          this.newUser.Role = "user";

        } else {

          console.log("something went wrong while saving the user: ", this.newUser);
        }

      });

    } else {

      console.log("Invalid user info : ", this.newUser);
    }
  }

}
