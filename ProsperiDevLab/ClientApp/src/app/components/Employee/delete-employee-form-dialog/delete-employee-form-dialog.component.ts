import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Employee } from 'src/app/models/employee.model';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-delete-employee-form-dialog',
  templateUrl: './delete-employee-form-dialog.component.html',
  styleUrls: ['./delete-employee-form-dialog.component.scss']
})
export class DeleteEmployeeFormDialogComponent implements OnInit {

  errors: any = {};

  constructor(
    @Inject(MAT_DIALOG_DATA) private _employee: Employee,
    private _snackBar: MatSnackBar,
    private _dialogRef: MatDialogRef<DeleteEmployeeFormDialogComponent>,
    private _employeeService: EmployeeService) { }

  ngOnInit(): void {

  }

  onSubmit(): void {
    this._employeeService.delete(this._employee.id!).subscribe(
      success => {
        this._dialogRef.close({ data: success });
      },
      fail => {
        this.errors = fail.error;
        this.showSnackBarErrors();
      }
    );
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
