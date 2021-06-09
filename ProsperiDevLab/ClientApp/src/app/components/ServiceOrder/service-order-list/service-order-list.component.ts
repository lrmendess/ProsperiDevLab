import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
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

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  serviceOrders: ServiceOrder[] = [];

  dataSource!: MatTableDataSource<ServiceOrder>;
  serviceOrdersColumns: string[] = [
    'number', 'title', 'customer', 'price',
    'executionDate', 'actions'
  ];

  dialogUIConfig: any = {
    width: "500px",
    minWidth: "250px",
  };

  constructor(
    private _dialog: MatDialog,
    private _serviceOrderService: ServiceOrderService) { }

  ngOnInit(): void {
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
        this.dataSource.paginator = this.paginator;
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

}
