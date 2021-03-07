import { Component, OnInit } from '@angular/core';
import { Provider } from '../models/provider';
import { ProvidersService } from '../services/orders.service';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ProviderCatalogueComponent } from '../provider-catalogue/provider-catalogue.component';

@Component({
  selector: 'app-providers-list',
  templateUrl: './providers-list.component.html',
  styleUrls: ['./providers-list.component.scss']
})
export class ProvidersListComponent implements OnInit {

  providerList : Array<Provider>;
  
  constructor(private providerSvc: ProvidersService, private matDialog: MatDialog) { }

  ngOnInit(): void {
    this.providerSvc.getAllProviders().subscribe((data) => {
      this.providerList = data;
    });
    
  }

  openDialog(id: number) {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.restoreFocus = true;
    dialogConfig.data = {providerId: id};
    this.matDialog.open(ProviderCatalogueComponent, dialogConfig);
  }

}
