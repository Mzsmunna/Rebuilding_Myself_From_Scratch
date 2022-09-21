import { Component, ElementRef, EventEmitter, Input, OnInit, Output, SimpleChange, SimpleChanges, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CustomValidation } from '../../../helpers/validations/custom-validation.model';
import { AuthService } from '../../../services/auth/auth.service';
import { IssueService } from '../../../services/features/issue/issue.service';
import { User } from '../../../view_models/auth/user.model';
import { Issue } from '../../../view_models/issue.model';

@Component({
  selector: 'app-add-issue',
  templateUrl: './add-issue.component.html',
  styleUrls: ['./add-issue.component.css']
})
export class AddIssueComponent implements OnInit {

  public newIssue: Issue;
  issueForm: FormGroup;

  @Input() loggedUser: User = {} as User;
  @Output() UpdateIssueList = new EventEmitter<Issue>();
  @ViewChild('closeModal', { static: false }) closeModal: ElementRef<HTMLButtonElement>;

  constructor(private authService: AuthService, private issueService: IssueService) {

    //this.loggedUser = {} as User;
    this.newIssue = {} as Issue;
    this.closeModal = {} as ElementRef;

    this.issueForm = new FormGroup({
      Title: new FormControl('', Validators.compose([Validators.required, Validators.minLength(10), Validators.pattern("[a-zA-Z ]*")])),
      Summary: new FormControl('', Validators.compose([Validators.required, Validators.minLength(20), Validators.pattern("[a-zA-Z ]*")])),
      Description: new FormControl('', Validators.minLength(30)),
      Type: new FormControl('to-do', Validators.required),
      AssignTo: new FormControl(this.authService.GetCurrentUserId(), Validators.required),
      StartDate: new FormControl(''),
      EndDate: new FormControl(''),
      DueDate: new FormControl(''),
      Status: new FormControl('pending', Validators.required),
      Comment: new FormControl('', Validators.pattern("[a-zA-Z ]*")),
      IsActive: new FormControl('false', Validators.required),
      IsDeleted: new FormControl('false', Validators.required),
      IsCompleted: new FormControl('false', Validators.required)
    }, //{ validators: CustomValidation.passwordMatchValidate }
    );
  }

  ngOnInit(): void {

    console.log(`ngOnInit: app-add-issue`, this.loggedUser);
  }

  ngOnChanges(changes: SimpleChanges) {

    console.log(`ngOnChanges: app-add-issue`);

    if (changes) {

      console.log(changes);
      //  console.log("app-ng-smart-table : updated data");
      //  console.log(changes['data']['currentValue']);
      //  this.data = changes['data']['currentValue'];
      //console.log(this.data);

      const currentItem: SimpleChange = changes["data"];
      //console.log('prev value: ', currentItem.previousValue);
      //console.log('got item: ', currentItem.currentValue);
      //this.loggedUser = changes['data']['currentValue'];
    }
  }

  SaveIssue(isValid: boolean) {

    if (isValid) {

      this.newIssue.Title = this.issueForm.value.Title;
      this.newIssue.Summary = this.issueForm.value.Summary;
      this.newIssue.Description = this.issueForm.value.Description;
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
