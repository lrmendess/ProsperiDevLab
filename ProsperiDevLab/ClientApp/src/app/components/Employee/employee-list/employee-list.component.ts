import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Employee } from 'src/app/models/employee.model';
import { EmployeeService } from 'src/app/services/employee.service';
import { CreateEmployeeFormDialogComponent } from '../create-employee-form-dialog/create-employee-form-dialog.component';
import { DeleteEmployeeFormDialogComponent } from '../delete-employee-form-dialog/delete-employee-form-dialog.component';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {

  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  employees: Employee[] = [];

  dataSource!: MatTableDataSource<Employee>;
  employeesColumns: string[] = [
    'name', 'cpf', 'actions'
  ];

  dialogUIConfig: any = {
    width: "500px",
    minWidth: "250px",
  };

  constructor(
    private _dialog: MatDialog,
    private _employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.retrieveAll();
  }

  retrieveAll() {
    this._employeeService.getAll().subscribe(
      response => {
        this.employees = response;
      },
      error => {
        this.employees = [];
      },
      () => {
        this.dataSource = new MatTableDataSource(this.employees);

        this.dataSource.sort = this.sort;
        this.dataSource.paginator = this.paginator;
      }
    );
  }

  openCreateEmployeeDialog(employee?: Employee): void {
    this._dialog
      .open(CreateEmployeeFormDialogComponent, { ...this.dialogUIConfig, data: employee })
      .afterClosed()
      .subscribe(() => {
        this.retrieveAll();
      });
  }

  openDeleteEmployeeDialog(employee: Employee): void {
    this._dialog
      .open(DeleteEmployeeFormDialogComponent, {...this.dialogUIConfig, data: employee })
      .afterClosed()
      .subscribe(() => {
        this.retrieveAll();
      });
  }

  applyFilter(value: string): void {
    this.dataSource.filterPredicate = (data: Employee, filter: string) => {
      const dataStr =
          data.name
        + data.cpf
        + data.cpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, "$1.$2.$3-$4");
      
      return dataStr.toLowerCase().includes(filter);
    };

    this.dataSource.filter = value.trim().toLowerCase();
  }

}
