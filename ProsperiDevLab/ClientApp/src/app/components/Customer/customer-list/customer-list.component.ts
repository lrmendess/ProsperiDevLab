import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Customer } from 'src/app/models/customer.model';
import { CustomerService } from 'src/app/services/customer.service';
import { CreateCustomerFormDialogComponent } from '../create-customer-form-dialog/create-customer-form-dialog.component';
import { DeleteCustomerFormDialogComponent } from '../delete-customer-form-dialog/delete-customer-form-dialog.component';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.scss']
})
export class CustomerListComponent implements OnInit {

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  customers: Customer[] = [];

  dataSource!: MatTableDataSource<Customer>;
  customersColumns: string[] = [
    'name', 'cnpj', 'actions'
  ];

  dialogUIConfig: any = {
    width: "500px",
    minWidth: "250px",
  };

  constructor(
    private _dialog: MatDialog,
    private _customerService: CustomerService) { }

  ngOnInit(): void {
    this.retrieveAll();
  }

  retrieveAll() {
    this._customerService.getAll().subscribe(
      response => {
        this.customers = response;
      },
      error => {
        this.customers = [];
      },
      () => {
        this.dataSource = new MatTableDataSource(this.customers);

        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      }
    );
  }

  openCreateCustomerDialog(customer?: Customer): void {
    this._dialog
      .open(CreateCustomerFormDialogComponent, { ...this.dialogUIConfig, data: customer })
      .afterClosed()
      .subscribe(() => {
        this.retrieveAll();
      });
  }

  openDeleteCustomerDialog(customer: Customer): void {
    this._dialog
      .open(DeleteCustomerFormDialogComponent, {...this.dialogUIConfig, data: customer })
      .afterClosed()
      .subscribe(() => {
        this.retrieveAll();
      });
  }

  applyFilter(value: string): void {
    this.dataSource.filterPredicate = (data: Customer, filter: string) => {
      const dataStr =
          data.name
        + data.cnpj
        + data.cnpj.replace(/(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})/, "$1.$2.$3/$4-$5");
      
      return dataStr.toLowerCase().includes(filter);
    };

    this.dataSource.filter = value.trim().toLowerCase();
  }

}
