import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteEmployeeFormDialogComponent } from './delete-employee-form-dialog.component';

describe('DeleteEmployeeFormDialogComponent', () => {
  let component: DeleteEmployeeFormDialogComponent;
  let fixture: ComponentFixture<DeleteEmployeeFormDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteEmployeeFormDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteEmployeeFormDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
