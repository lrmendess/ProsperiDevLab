import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Employee } from 'src/app/models/employee.model';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-create-employee-form-dialog',
  templateUrl: './create-employee-form-dialog.component.html',
  styleUrls: ['./create-employee-form-dialog.component.scss']
})
export class CreateEmployeeFormDialogComponent implements OnInit {

  employee: Employee = { } as Employee;
  
  errors: any = {};

  constructor(
    @Inject(MAT_DIALOG_DATA) public _employee: Employee,
    private _dialogRef: MatDialogRef<CreateEmployeeFormDialogComponent>,
    private _snackBar: MatSnackBar,
    private _employeeService: EmployeeService) { }

  ngOnInit(): void {
    if (this._employee) {
      this.employee = { ...this._employee };
    }
  }

  onSubmit(): void {
    this.errors = {};

    if (this._employee) {
      this._employeeService
        .update(this._employee.id!, this.employee)
        .subscribe(
          success => {
            this._dialogRef.close({ data: success });
          },
          fail => {
            this.errors = fail.error;
            this.showSnackBarErrors();
          }
        );
    } else {
      this._employeeService
        .create(this.employee)
        .subscribe(
          success => {
            this._dialogRef.close({ data: success });
          },
          fail => {
            this.errors = fail.error;
            this.showSnackBarErrors();
          }
        );
    }
  }

  showSnackBarErrors(): void {
    const snackBarConfig: any = {
      duration: 3000,
      verticalPosition: 'top',
    };

    const emptyErrors = this.errors[''];

    if (emptyErrors) {
      this._snackBar.open(emptyErrors[0], 'OK', snackBarConfig);
    }
  }

}
