import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { map } from 'rxjs/operators';
import { CatalogueItem } from '../models/catalogue-item';
import { Provider } from '../models/provider';
import { ProviderCatalogue } from '../models/provider-catalogue';
import { ProvidersService } from '../services/providers.service';

@Component({
  selector: 'app-provider-catalog',
  templateUrl: './provider-catalog.component.html',
  styleUrls: ['./provider-catalog.component.scss'],
})
export class ProviderCatalogComponent implements OnInit {
  data: Array<ProviderCatalogue>;
  constructor(
    private providerSvc: ProvidersService,
    @Inject(MAT_DIALOG_DATA) public provider: Provider
  ) {}

  ngOnInit(): void {
    this.providerSvc
      .getProviderMenu(this.provider.id)
      .pipe(
        map((items) => {
          let providerCatalogue: Array<ProviderCatalogue> = [];
          items.forEach((item) => {
            let catalogueItem = providerCatalogue.find(
              (e) => e.id === item.category.id
            );
            if (!catalogueItem) {
              providerCatalogue.push({
                id: item.category.id,
                description: item.category.name,
                items: [],
              });
              catalogueItem = providerCatalogue.find(
                (e) => e.id === item.category.id
              );
            }

            catalogueItem.items.push({
              id: item.id,
              name: item.name,
              price: item.price,
            });
          });
          return providerCatalogue;
        })
      )
      .subscribe((data) => {
        this.data = data;
      });
  }
}