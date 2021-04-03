import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ValidationErrors } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from '../models/user';
import { UsersService } from '../services/users.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  formGroup: FormGroup;
  
  constructor(
    private router: Router, 
    private formBuilder: FormBuilder, 
    private userSvc: UsersService
    ) { }

  ngOnInit(): void {
    //TODO validations
    this.formGroup = this.formBuilder.group({
      firstName: new FormControl(),
      lastName: new FormControl(),
      password: new FormControl(),
      repeatPassword: new FormControl(),
      username: new FormControl(),
      email: new FormControl(),
      phone: new FormControl(),
      address: new FormControl(),
    });
  }

  register() {
    if (this.formGroup.valid) {
      const form = this.formGroup.value;
      if (form.password === form.repeatPassword)
        this.createNewUser(form);
      else 
        console.log("Not the same password");
    } else {
      this.getFormValidationErrors();
    }
  }

  createNewUser(userForm: any) {
    var newUser = new User ();
    newUser.firstName = userForm.firstName;
    newUser.lastName = userForm.lastName;
    newUser.email = userForm.email;
    newUser.password = userForm.password;
    newUser.phoneNumber = userForm.repeatPassword;
    newUser.address = userForm.address;
    newUser.username = userForm.username;
    this.userSvc.postUser(newUser).subscribe(resp => console.log(resp));
  }

  showUsers()
  {
    this.userSvc.getUsers().subscribe(resp => console.log(resp));
  }

  testOptions()
  {
    this.userSvc.getOptions().subscribe(resp => console.log(resp));
  }

  getFormValidationErrors() {
    Object.keys(this.formGroup.controls).forEach((key) => {
      const controlErrors: ValidationErrors = this.formGroup.get(key).errors;
      if (controlErrors != null) {
        Object.keys(controlErrors).forEach((keyError) => {
          console.log(
            'Key control: ' + key + ', keyError: ' + keyError + ', err value: ',
            controlErrors[keyError]
          );
        });
      }
    });
  }

  changeVisibility()
  {
    var password = (<HTMLInputElement>document.getElementById("password"));
    if (password.type === "password") {
      password.type = "text";
    } else {
      password.type = "password";
    }
    
    var repatPassword = (<HTMLInputElement>document.getElementById("repeatPassword"));
    if (repatPassword.type === "password") {
      repatPassword.type = "text";
    } else {
      repatPassword.type = "password";
    }
  }
}

 