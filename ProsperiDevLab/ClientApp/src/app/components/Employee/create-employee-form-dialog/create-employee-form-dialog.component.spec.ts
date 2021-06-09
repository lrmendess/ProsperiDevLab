import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateEmployeeFormDialogComponent } from './create-employee-form-dialog.component';

describe('CreateEmployeeFormDialogComponent', () => {
  let component: CreateEmployeeFormDialogComponent;
  let fixture: ComponentFixture<CreateEmployeeFormDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateEmployeeFormDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateEmployeeFormDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
