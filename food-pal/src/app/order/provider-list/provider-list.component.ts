import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { ProvidersService } from 'src/app/order/services/providers.service';
import { Provider } from '../models/provider';
import { ProviderCatalogComponent } from '../provider-catalog/provider-catalog.component';

@Component({
  selector: 'app-provider-list',
  templateUrl: './provider-list.component.html',
  styleUrls: ['./provider-list.component.scss'],
})
export class ProviderListComponent {
  data: Array<Provider>;
  providers$: Observable<Array<Provider>>;

  constructor(
    private providerSvc: ProvidersService,
    private dialog: MatDialog
  ) {
    this.providers$ = this.providerSvc.getAllProviders().pipe(
      tap((data) => {
        this.data = data;
      })
    );
  }

  openCatalog(providerId: number) {
    const provider = this.data.find((f) => f.id === providerId);
    const dialogRef = this.dialog.open(ProviderCatalogComponent, {
      data: provider,
    });
    dialogRef.afterClosed().subscribe((result) => {
      console.log(result);
    });
  }
}