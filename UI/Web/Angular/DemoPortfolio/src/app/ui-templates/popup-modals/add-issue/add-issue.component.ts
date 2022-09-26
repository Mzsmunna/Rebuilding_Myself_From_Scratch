import { formatDate } from '@angular/common';
import { Component, ElementRef, EventEmitter, Input, OnInit, Output, SimpleChange, SimpleChanges, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CustomValidation } from '../../../helpers/validations/custom-validation.model';
import { AuthService } from '../../../services/auth/auth.service';
import { AlertService } from '../../../services/common/alert/alert.service';
import { IssueService } from '../../../services/features/issue/issue.service';
import { UserService } from '../../../services/features/user/user.service';
import { AssignUser, User } from '../../../view_models/auth/user.model';
import { Issue } from '../../../view_models/issue.model';
declare var window: any;

@Component({
  selector: 'app-add-issue',
  templateUrl: './add-issue.component.html',
  styleUrls: ['./add-issue.component.css']
})
export class AddIssueComponent implements OnInit {

  public newIssue: Issue;
  public existingIssue: Issue;
  issueForm: FormGroup;

  public assignUserList: AssignUser[];

  @Input() loggedUser: User = {} as User;
  @Output() UpdateIssueList = new EventEmitter<Issue>();
  @ViewChild('closeModal', { static: false }) closeModal: ElementRef<HTMLButtonElement>;
  @ViewChild('issuePopUp', { static: false }) issuePopUp: any;

  formModal: any;
  actionName: string = "Add";

  action: string;

  isAdmin: boolean = false;

  constructor(private authService: AuthService, private issueService: IssueService, private userService: UserService, private alertService: AlertService) {

    this.action = "Adding";

    //this.loggedUser = {} as User;
    this.assignUserList = [] as AssignUser[];

    this.newIssue = {} as Issue;
    this.existingIssue = {} as Issue;
    this.closeModal = {} as ElementRef;
    this.issueForm = {} as FormGroup;
    this.Reset();
  }

  ngOnInit(): void {

    console.log(`ngOnInit: app-add-issue`, this.loggedUser);
    this.GetAllUserToAssign();
    this.isAdmin = this.authService.IsAdmin();
  }

  ngOnChanges(changes: SimpleChanges) {

    console.log(`ngOnChanges: app-add-issue`);

    if (changes) {

      console.log(changes);

      //const currentItem: SimpleChange = changes["data"];
      //console.log('prev value: ', currentItem.previousValue);
      //console.log('got item: ', currentItem.currentValue);
      //this.loggedUser = changes['data']['currentValue'];
    }

    this.issueForm.get('Type')?.valueChanges
      .subscribe(value => {

      //this.ConditionalFormValidation("Type", value);
    });
  }

  ngAfterViewInit() {

  }

  ConditionalFormValidation(key: string, $event: any) {

    var value = $event.target?.value;
    let formControl = null;

    if (key && value) {

      if (key.toLowerCase() == "type") {

        if (value.toLowerCase().includes("to-do")) {

          //this.issueForm.get('myEmailField')?.setValidators(this.emailValidators.concat(Validators.required));

        } else {

          //this.issueForm.get('myEmailField')?.clearValidators();
        }

        if (value.toLowerCase().includes("task")) {

          formControl = this.issueForm.get('StartDate');
          formControl?.setValidators(Validators.required);
          formControl?.updateValueAndValidity();

          formControl = this.issueForm.get('EndDate')
          formControl?.setValidators(Validators.required);
          formControl?.updateValueAndValidity();

        } else {

          formControl = this.issueForm.get('StartDate');
          formControl?.clearValidators();
          formControl?.updateValueAndValidity();

          formControl = this.issueForm.get('EndDate');
          formControl?.clearValidators();
          formControl?.updateValueAndValidity();
        }

        if (value.toLowerCase().includes("note")) {

          formControl = this.issueForm.get('Comment');
          formControl?.setValidators(Validators.required);
          formControl?.updateValueAndValidity();

        } else {

          formControl = this.issueForm.get('Comment');
          formControl?.clearValidators();
          formControl?.updateValueAndValidity();
        }

        if (value.toLowerCase().includes("reminder")) {

          formControl = this.issueForm.get('DueDate');
          formControl?.setValidators(Validators.required);
          formControl?.updateValueAndValidity();

        } else {

          formControl = this.issueForm.get('DueDate');
          formControl?.clearValidators();
          formControl?.updateValueAndValidity();
        }
      }
    }
  }

  GetAllUserToAssign() {

    this.userService.GetAllUserToAssign().subscribe(result => {

      console.log(result);

      this.assignUserList = result as AssignUser[];

    });
  }

  ReopenIssue(): void {

    this.actionName = "Update";
    this.existingIssue.IsCompleted = false;
    this.issueForm.enable();
  }

  public EnableUpdateMode(issue: Issue): void {

    console.log(`EnableUpdateMode for issue`, issue);

    this.existingIssue = issue;
    this.issueForm.enable();

    if (this.existingIssue) {

      this.BindFormValue(this.existingIssue);

      if (this.existingIssue.IsCompleted) {

        this.actionName = "Closed";
        this.issueForm.disable();

      } else {

        this.actionName = "Update";
      }

      this.formModal = new window.bootstrap.Modal(
        document.getElementById('issuePopUp')
      );
      
      this.formModal.show();
    }
  }

  Reset(): void {

    this.actionName = "Add";

    this.existingIssue = {} as Issue;

    this.newIssue = {
      Id: '',
      ProjectId: '',
      Title: '',
      Type: 'to-do',
      Summary: '',
      Description: '',
      AssignedName: '',
      AssignedImg: '',
      AssignedId: this.authService.GetCurrentUserId(),
      LogTime: null,
      StartDate: null,
      EndDate: null,
      DueDate: null,
      Status: 'pending',
      Comment: '',
      IsActive: false,
      IsDeleted: false,
      IsCompleted: false,
      CreatedOn: new Date(),
      ModifiedOn: null,
      CreatedBy: this.authService.GetCurrentUserId(),
      CreatedByName: '',
      CreatedByImg: '',
      ModifiedBy: ''
    };

    this.BindFormValue(this.newIssue);
  }

  BindFormValue(bindIssue: Issue) {

    this.issueForm = new FormGroup({
      Title: new FormControl(bindIssue.Title, Validators.compose([Validators.required, Validators.minLength(10), Validators.pattern("[a-zA-Z ]*")])),
      Summary: new FormControl(bindIssue.Summary, Validators.compose([Validators.required, Validators.minLength(20), Validators.pattern("^([^0-9]*)$")])),
      Description: new FormControl(bindIssue.Description, Validators.compose([Validators.minLength(30), Validators.pattern(".*?[^0-9].*")])),
      Type: new FormControl(bindIssue.Type, Validators.required),
      AssignTo: new FormControl(bindIssue.AssignedId, Validators.required),
      StartDate: new FormControl(this.FormateDate(bindIssue.StartDate)),
      EndDate: new FormControl(this.FormateDate(bindIssue.EndDate)),
      DueDate: new FormControl(this.FormateDate(bindIssue.DueDate)),
      Status: new FormControl(bindIssue.Status, Validators.required),
      Comment: new FormControl(bindIssue.Comment, Validators.pattern(".*?[^0-9].*")),
      //IsActive: new FormControl(bindIssue.IsActive, Validators.required),
      //IsDeleted: new FormControl(bindIssue.IsDeleted, Validators.required),
      //IsCompleted: new FormControl(bindIssue.IsCompleted, Validators.required)
    }, //{ validators: CustomValidation.passwordMatchValidate }
    );
  }

  FormateDate(date: Date | null) {

    if (date) {

      return formatDate(date, "yyyy-MM-dd", "en");
    }
    else
      return date;
  }

  SaveIssue(isValid: boolean) {

    if (isValid) {

      if (this.existingIssue) {

        this.newIssue = this.existingIssue;
      }

      this.newIssue.Title = this.issueForm.value.Title;
      this.newIssue.Summary = this.issueForm.value.Summary;
      this.newIssue.Description = this.issueForm.value.Description;
      this.newIssue.Type = this.issueForm.value.Type;
      this.newIssue.Status = this.issueForm.value.Status;
      this.newIssue.AssignedId = this.issueForm.value.AssignTo;
      this.newIssue.StartDate = new Date(this.issueForm.value.StartDate);
      this.newIssue.EndDate = new Date(this.issueForm.value.EndDate);
      this.newIssue.DueDate = new Date(this.issueForm.value.DueDate);
      this.newIssue.IsActive = this.issueForm.value.IsActive;
      this.newIssue.IsDeleted = this.issueForm.value.IsDeleted;
      this.newIssue.IsCompleted = this.issueForm.value.IsCompleted;

      if (this.newIssue.Id) {

        this.newIssue.ModifiedBy = this.authService.GetCurrentUserId();
        this.action = "Updating";
      }
      else {

        this.newIssue.CreatedBy = this.authService.GetCurrentUserId();
        this.action = "Adding";
      }
        
      this.issueService.SaveIssue(this.newIssue).subscribe(result => {

        console.log("saved issue: ", result);
        this.alertService.Success(this.action + " Issue: '" + this.newIssue.Title + "' has been Successful!", "Yay!!", true);

        if (result) {

          this.closeModal.nativeElement.click();
          this.issueForm.reset();
          this.UpdateIssueList.emit(result);

        } else {

          console.log("something went wrong while saving the Issue: ", this.newIssue);
          this.alertService.Error("something went wrong while " + this.action + " the Issue: " + this.newIssue.Title, "Opps!!", true);
        }

      });

    } else {

      console.log("Invalid issue info : ", this.newIssue);
      this.alertService.Error("Issue Form is invalid", "Opps!!", true);
    }
  }
}
