import { Component, ElementRef, EventEmitter, Input, OnInit, Output, SimpleChange, SimpleChanges, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CustomValidation } from '../../../helpers/validations/custom-validation.model';
import { AuthService } from '../../../services/auth/auth.service';
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

  constructor(private authService: AuthService, private issueService: IssueService, private userService: UserService) {

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
      AssignedId: this.authService.GetCurrentUserId(),
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
      ModifiedBy: ''
    };

    this.BindFormValue(this.newIssue);
  }

  BindFormValue(bindIssue: Issue) {

    this.issueForm = new FormGroup({
      Title: new FormControl(bindIssue.Title, Validators.compose([Validators.required, Validators.minLength(10), Validators.pattern("[a-zA-Z ]*")])),
      Summary: new FormControl(bindIssue.Summary, Validators.compose([Validators.required, Validators.minLength(20), Validators.pattern("[a-zA-Z ]*")])),
      Description: new FormControl(bindIssue.Description, Validators.minLength(30)),
      Type: new FormControl(bindIssue.Type, Validators.required),
      AssignTo: new FormControl(bindIssue.AssignedId, Validators.required),
      StartDate: new FormControl(bindIssue.StartDate),
      EndDate: new FormControl(bindIssue.EndDate),
      DueDate: new FormControl(bindIssue.DueDate),
      Status: new FormControl(bindIssue.Status, Validators.required),
      Comment: new FormControl(bindIssue.Comment, Validators.pattern("[a-zA-Z ]*")),
      //IsActive: new FormControl(bindIssue.IsActive, Validators.required),
      //IsDeleted: new FormControl(bindIssue.IsDeleted, Validators.required),
      //IsCompleted: new FormControl(bindIssue.IsCompleted, Validators.required)
    }, //{ validators: CustomValidation.passwordMatchValidate }
    );
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
  }

  ngAfterViewInit() {
    
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
      this.newIssue.AssignedId = this.issueForm.value.AssignTo;
      this.newIssue.StartDate = new Date(this.issueForm.value.StartDate);
      this.newIssue.EndDate = new Date(this.issueForm.value.EndDate);
      this.newIssue.DueDate = new Date(this.issueForm.value.DueDate);
      this.newIssue.IsActive = this.issueForm.value.IsActive;
      this.newIssue.IsDeleted = this.issueForm.value.IsDeleted;
      this.newIssue.IsCompleted = this.issueForm.value.IsCompleted;

      if (this.newIssue.Id)
        this.newIssue.ModifiedBy = this.authService.GetCurrentUserId();
      else
        this.newIssue.CreatedBy = this.authService.GetCurrentUserId();

      this.issueService.SaveIssue(this.newIssue).subscribe(result => {

        console.log("saved issue: ", result);

        if (result) {

          this.closeModal.nativeElement.click();
          this.issueForm.reset();
          this.UpdateIssueList.emit(result);

        } else {

          console.log("something went wrong while saving the Issue: ", this.newIssue);
        }

      });

    } else {

      console.log("Invalid issue info : ", this.newIssue);
    }
  }
}
