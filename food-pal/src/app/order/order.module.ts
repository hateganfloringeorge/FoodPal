import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderComponent } from './order/order.component';
import { ProvidersListComponent } from './providers-list/providers-list.component';
import { ProviderCatalogueComponent } from './provider-catalogue/provider-catalogue.component';
import { OrderRoutingModule } from './order-routing.module';
import { MatButtonModule} from '@angular/material/button';
import { ProvidersService } from './services/orders.service';
import { HttpClientModule } from '@angular/common/http';
import { MatDialogModule } from "@angular/material/dialog";
import { MatTableModule } from '@angular/material/table';


const materialImports = [MatButtonModule, MatDialogModule, MatTableModule];

@NgModule({
  declarations: [OrderComponent, ProvidersListComponent, ProviderCatalogueComponent],
  imports: [CommonModule, OrderRoutingModule, HttpClientModule, ...materialImports],
  providers: [ProvidersService],
  entryComponents: [ProviderCatalogueComponent],

})

export class OrderModule { }
