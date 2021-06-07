import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ServiceOrder } from 'src/app/models/service-order.model';
import { CreateServiceOrderFormComponent } from '../create-service-order-form-dialog/create-service-order-form-dialog.component';
import { DeleteServiceOrderDialogComponent } from '../delete-service-order-form-dialog/delete-service-order-form-dialog.component';

@Component({
  selector: 'app-service-order-list',
  templateUrl: './service-order-list.component.html',
  styleUrls: ['./service-order-list.component.scss']
})
export class ServiceOrderListComponent implements OnInit {

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  /**
   * Table config
   */
  serviceOrders: ServiceOrder[] = [];
  dataSource: MatTableDataSource<ServiceOrder>;
  serviceOrdersColumns: string[] = [
    'number', 'title', 'customer', 'price',
    'executionDate', 'actions'
  ];

  dialogUIConfig: any = {
    width: "500px",
    minWidth: "250px",
  };

  constructor(public dialog: MatDialog) {
    this.serviceOrders = this.mockServiceOrders();
    this.dataSource = new MatTableDataSource(this.serviceOrders);
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  ngOnInit(): void {
  }

  openCreateServiceOrderDialog(serviceOrder?: ServiceOrder): void {
    if (serviceOrder) {
      // {Edit}
      // return
    }
    
    this.dialog.open(CreateServiceOrderFormComponent, {...this.dialogUIConfig,
      data: serviceOrder
    });
  }

  openDeleteServiceOrderDialog(serviceOrder: ServiceOrder): void {
    this.dialog.open(DeleteServiceOrderDialogComponent, {...this.dialogUIConfig,
      data: serviceOrder
    });
  }

  mockServiceOrders(): ServiceOrder[] {
    let arr: ServiceOrder[] = [];

    for (let i: number = 1; i < 16; i++) {
      let zeros: string = '0000'.substr(i.toString().length - 1);

      arr.push({
        id: i,
        number: zeros + i + '-SO',
        title: 'Lorem Ipsum',
      });
    }

    return arr;
  }

}
