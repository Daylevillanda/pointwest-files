import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-fb-form',
  templateUrl: './fb-form.component.html',
  styleUrls: ['./fb-form.component.css']
})
export class FbFormComponent{
  myForm: FormGroup;

  @Output() customSubmit = new EventEmitter();

  constructor(fb: FormBuilder) {
    this.myForm = fb.group({
      email: ['', [
        Validators.required,
        Validators.pattern(/^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/g)
      ]],
      phone: ['', [
        Validators.required,
        Validators.pattern(/^09[0-9]{9}$/g)
      ]],
      address: fb.group({
        street: ['', Validators.required],
        city: ['', Validators.required],
        postalCode: ['', Validators.required]
      })
    });
  }

  onSubmit() {
    this.customSubmit.emit(this.myForm.value);
  }

  get email() {
    return this.myForm.get('email');
  }

  get phone() {
    return this.myForm.get('phone');
  }

}
