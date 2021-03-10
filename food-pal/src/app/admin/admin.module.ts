import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ProvidersComponent } from './providers/providers.component';
import { AdminComponent } from './admin/admin.component';
import { AdminRoutingModule } from './admin-routing.module';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { ProvidersService } from './services/providers.service';
import { HttpClientModule } from '@angular/common/http';
import { MatSortModule } from '@angular/material/sort';
import { MatInputModule } from '@angular/material/input';
import { ProviderEditComponent } from './provider-edit/provider-edit.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';

const materialImports = [
  MatButtonModule,
  MatTableModule,
  MatSortModule,
  MatFormFieldModule,
  MatInputModule,
];

@NgModule({
  declarations: [
    DashboardComponent,
    ProvidersComponent,
    AdminComponent,
    ProviderEditComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    ...materialImports,
  ],
  providers: [ProvidersService],
})
export class AdminModule {}