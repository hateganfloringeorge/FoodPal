import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegisterComponent } from './register/register.component';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserComponent } from './user/user.component';
import { UserRoutingModule } from './user-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { UsersService } from './services/users.service';

const materialImports = [
  MatButtonModule,
  MatFormFieldModule,
  MatIconModule,
  MatInputModule,
  MatCheckboxModule,
];

@NgModule({
  declarations: [RegisterComponent, UserComponent],
  imports: [
    CommonModule,
    HttpClientModule,
    UserRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    ...materialImports,
  ],
  providers: [UsersService],
})
export class UserModule { }
