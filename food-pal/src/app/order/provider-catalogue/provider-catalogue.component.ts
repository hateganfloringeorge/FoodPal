import { Component, OnInit, Inject } from '@angular/core';
import { ProvidersService } from '../services/orders.service';
import {
  MatDialogRef,
  MAT_DIALOG_DATA
} from "@angular/material/dialog";
import { Catalogue } from '../models/catalogue';

@Component({
  selector: 'app-provider-catalogue',
  templateUrl: './provider-catalogue.component.html',
  styleUrls: ['./provider-catalogue.component.scss']
})


export class ProviderCatalogueComponent implements OnInit {

  catalogue : Catalogue;
  displayedColumns: string[] = ['id', 'name', 'price']
  
  constructor(
    private providerSvc: ProvidersService,
    @Inject(MAT_DIALOG_DATA) public data: any, 
    public dialogRef: MatDialogRef<ProviderCatalogueComponent> 
    ) { }

  ngOnInit(): void {}

  ngAfterViewInit(): void {

      this.providerSvc.getProviderWithCatalogue(this.data.providerId).subscribe((data) => {
        this.catalogue = data.catalogue;
      });

  }

  close() {
    this.dialogRef.close();
  }

}
