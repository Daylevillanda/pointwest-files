import { Component, OnInit, Output, EventEmitter} from '@angular/core';
import { Observable, tap } from 'rxjs';
import { IUserRegistrations } from './Model/userregistrations';
import { RegistrationService } from './registration.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})

export class RegistrationComponent implements OnInit {
  newUser: IUserRegistrations = {
    EmailAddress: "",
    Password: "",
    ConfirmPassword: "",
    FirstName: "",
    LastName: "",
    Birthdate: "",
    Gender: "",
    MobileNumber: ""
  }

  constructor(private registrationService: RegistrationService) {}

  registrationform = new FormGroup(
    {
    EmailAddress: new FormControl('', [
      Validators.required,
      Validators.pattern(/^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{3,}))$/g)
    ]),
      Password: new FormControl('', [
      Validators.required,
    ]),
    ConfirmPassword: new FormControl('', [
      Validators.required,
    ]),
    FirstName: new FormControl('', [
      Validators.required,
      Validators.minLength(4),
      Validators.pattern(/^[A-Za-z ]+$/)
    ]),
    LastName: new FormControl('', [
      Validators.required,
      Validators.pattern(/^[A-Za-z ]+$/)
    ]),
    Birthdate: new FormControl('', [
      Validators.required
    ]),
    Gender: new FormControl('', [
      Validators.pattern(/^[A-Za-z ]+$/)
    ]),
    MobileNumber: new FormControl('', [
      Validators.pattern(/^09[0-9]{9}$/g)
    ]), 
  },
  
  );
  @Output() customSubmit = new EventEmitter();

  onSubmit() {
    this.customSubmit.emit(this.registrationform.value);
  }

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
  
  get Birthdate() {
    return this.registrationform.get('Birthdate');
  }
  
  get Gender() {
    return this.registrationform.get('Gender');
  }
  
  get MobileNumber() {
    return this.registrationform.get('MobileNumber');
  }

  ngOnInit(): void {  }

  addNewUser(): void {
    // this.userfriendService.addFriend(this.userfriend);
    // console.log(this.userfriend);
    this.newUser = this.registrationform.value;
    this.registrationService.addUser(this.newUser).subscribe(newUser => this.newUser = newUser);
    this.registrationform.reset();
  }
}
