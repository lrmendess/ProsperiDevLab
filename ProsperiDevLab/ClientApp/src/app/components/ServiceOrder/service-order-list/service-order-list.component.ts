import { CurrencyPipe, DatePipe } from '@angular/common';
import { dashCaseToCamelCase } from '@angular/compiler/src/util';
import { Component, HostListener, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { DeviceDetectorService } from 'ngx-device-detector';
import { ServiceOrder } from 'src/app/models/service-order.model';
import { ServiceOrderService } from 'src/app/services/service-order.service';
import { CreateServiceOrderFormDialogComponent } from '../create-service-order-form-dialog/create-service-order-form-dialog.component';
import { DeleteServiceOrderDialogComponent } from '../delete-service-order-form-dialog/delete-service-order-form-dialog.component';

@Component({
  selector: 'app-service-order-list',
  templateUrl: './service-order-list.component.html',
  styleUrls: ['./service-order-list.component.scss']
})
export class ServiceOrderListComponent implements OnInit {

  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  serviceOrders: ServiceOrder[] = [];
  dataSource!: MatTableDataSource<ServiceOrder>;

  serviceOrdersColumns: string[] = [];

  serviceOrdersColumnsDesktop: string[] = [
    'number', 'title', 'customer', 'price', 'executionDate', 'actions'
  ];

  serviceOrdersColumnsMobile: string[] = [
    'number', 'price', 'executionDate', 'actions'
  ];

  dialogUIConfig: any = {
    width: "500px",
    minWidth: "250px",
  };

  constructor(
    private _dialog: MatDialog,
    private _datePipe: DatePipe,
    private _currencyPipe: CurrencyPipe,
    private _deviceService: DeviceDetectorService,
    private _serviceOrderService: ServiceOrderService) { }

  ngOnInit(): void {
    if (this._deviceService.isDesktop()) {
      this.serviceOrdersColumns = this.serviceOrdersColumnsDesktop;
    } else {
      this.serviceOrdersColumns = this.serviceOrdersColumnsMobile;
    }
      
    this.retrieveAll();
  }

  retrieveAll() {
    this._serviceOrderService.getAll().subscribe(
      response => {
        this.serviceOrders = response;
      },
      error => {
        this.serviceOrders = [];
      },
      () => {
        this.dataSource = new MatTableDataSource(this.serviceOrders);
        
        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;

        this.dataSource.sortingDataAccessor = (data: ServiceOrder, property: string) => {
          switch (property) {
            case 'number': return data.number;
            case 'title': return data.title;
            case 'customer': return data.customer?.name!;
            case 'price': return data.price.value;
            case 'executionDate': return this._datePipe.transform(data.executionDate, 'yyyy-MM--dd')!;
            default: return data.id!;
          }
        };
      }
    );
  }

  openCreateServiceOrderDialog(serviceOrder?: ServiceOrder): void {
    this._dialog
      .open(CreateServiceOrderFormDialogComponent, { ...this.dialogUIConfig, data: serviceOrder })
      .afterClosed()
      .subscribe(() => {
        this.retrieveAll();
      });
  }

  openDeleteServiceOrderDialog(serviceOrder: ServiceOrder): void {
    this._dialog
      .open(DeleteServiceOrderDialogComponent, {...this.dialogUIConfig, data: serviceOrder })
      .afterClosed()
      .subscribe(() => {
        this.retrieveAll();
      });
  }

  applyFilter(value: string): void {
    this.dataSource.filterPredicate = (data: ServiceOrder, filter: string) => {
      const dataStr =
          data.number
        + data.title
        + data.customer?.name
        + this._currencyPipe.transform(data.price.value, data.price.currency?.code) 
        + this._datePipe.transform(data.executionDate, 'MM/dd/yyyy');
      
      return dataStr.toLowerCase().includes(filter);
    };
    
    this.dataSource.filter = value.trim().toLowerCase();
  }

}
