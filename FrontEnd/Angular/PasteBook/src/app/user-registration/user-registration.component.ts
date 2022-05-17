import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { IUser_Registrations } from './Model/user-registrations';
import { UserRegistrationService } from './user-registration.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.scss']
})
export class UserRegistrationComponent implements OnInit {
  newUser: IUser_Registrations = {
    EmailAddress: "",
    Password: "",
    FirstName: "",
    LastName: "",
    Birthday: "",
    Gender: "",
    MobileNumber: ""
  }

  registrationform = new FormGroup({
    EmailAddress: new FormControl('', [
      Validators.required,
      Validators.pattern(/^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/g)
    ]),
      Password: new FormControl('', [
      Validators.required,
    ]),
    // ConfirmPassword: new FormControl('', [
    //   Validators.required,
    // ]),
    FirstName: new FormControl('', [
      Validators.required,
      Validators.pattern(/^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$/g)
    ]),
    LastName: new FormControl('', [
      Validators.required,
      Validators.pattern(/^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$/g)
    ]),
    Birthday: new FormControl('', [
      Validators.required
    ]),
    Gender: new FormControl('', [
      Validators.minLength(4),
      Validators.maxLength(6),
      Validators.pattern(/^[a-zA-Z]+(([',.-][a-zA-Z])?[a-zA-Z]*)*$/g)
    ]),
    MobileNumber: new FormControl('', [
      Validators.pattern(/^09[0-9]{9}$/g)
    ]),
  });
  // @Output() customSubmit = new EventEmitter();

  // onSubmit() {
  //   this.customSubmit.emit(this.registrationform.value);
  // }

  get EmailAddress() {
    return this.registrationform.get('EmailAddress');
  }

  get Password() {
    return this.registrationform.get('Password');
  }

  get FirstName() {
    return this.registrationform.get('FirstName');
  }
  
  get LastName() {
    return this.registrationform.get('LastName');
  }
  
  get Birthday() {
    return this.registrationform.get('Birthday');
  }
  
  get Gender() {
    return this.registrationform.get('Gender');
  }
  
  get MobileNumber() {
    return this.registrationform.get('MobileNumber');
  }
  
  userregistration$: Observable<IUser_Registrations[]> | undefined;
  
  constructor(private userregistrationService: UserRegistrationService) {}

  ngOnInit(): void {  }

  addNewUser(): void {
    // const user = {
    //   EmailAddress: this.newUser.EmailAddress,
    //   Password: this.newUser.Password,
    //   FirstName: this.newUser.FirstName,
    //   LastName: this.newUser.LastName,
    //   Birthday: this.newUser.Birthday,
    //   Gender: this.newUser.Gender,
    //   MobileNumber: this.newUser.MobileNumber
    // }
    // this.userfriendService.addFriend(this.userfriend);
    // console.log(this.userfriend);
    this.userregistrationService.addUser(this.newUser).subscribe(newUser => this.newUser = newUser);
    console.log("Success!");
  }


}
