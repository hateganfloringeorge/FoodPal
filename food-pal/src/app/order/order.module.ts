import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrderRoutingModule } from './order-routing.module';
import { OrderComponent } from './order/order.component';
import { ProviderListComponent } from './provider-list/provider-list.component';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { ProvidersService } from './services/providers.service';
import { HttpClientModule } from '@angular/common/http';
import { ProviderCatalogComponent } from './provider-catalog/provider-catalog.component';

const materialImports = [MatButtonModule, MatDialogModule];

@NgModule({
  declarations: [
    OrderComponent,
    ProviderListComponent,
    ProviderCatalogComponent,
  ],
  imports: [
    CommonModule,
    OrderRoutingModule,
    HttpClientModule,
    ...materialImports,
  ],
  providers: [ProvidersService],
})
export class OrderModule {}