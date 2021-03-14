import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  username: string;
  password: string;

  formGroup: FormGroup;
  
  constructor(private router: Router, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.formGroup = this.formBuilder.group({
      firstName: new FormControl(),
      lastName: new FormControl(),
      password: new FormControl(),
      repeatPassword: new FormControl(),
      email: new FormControl(),
      phone: new FormControl(),
      address: new FormControl(),
    });
  }

  register() {

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
