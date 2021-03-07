import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Provider } from '../models/provider';
import { ProvidersService } from '../services/providers.service';

@Component({
  selector: 'app-providers',
  templateUrl: './providers.component.html',
  styleUrls: ['./providers.component.scss'],
})
export class ProvidersComponent implements OnInit, AfterViewInit {
  x: Array<Provider>;
  displayedColumns: string[] = ['id', 'name', 'location'];

  @ViewChild(MatSort) sort: MatSort;
  datasource = new MatTableDataSource<Provider>();

  constructor(private providersSvc: ProvidersService) {}

  ngOnInit(): void {}

  ngAfterViewInit() {
    this.providersSvc.getAllProviders().subscribe((data) => {
      this.x = data;
      this.datasource = new MatTableDataSource<Provider>(this.x);
      this.datasource.sort = this.sort;
    });
  }
}