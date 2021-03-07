import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OrderComponent } from './order/order.component';
import { ProviderCatalogueComponent } from './provider-catalogue/provider-catalogue.component';
import { ProvidersListComponent } from './providers-list/providers-list.component';

const routes: Routes = [
  {
    path: '',
    component: OrderComponent,
    children: [
      { path: '', component: ProvidersListComponent },
      { path: '', component: ProviderCatalogueComponent}
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class OrderRoutingModule {}