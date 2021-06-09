import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateCustomerFormDialogComponent } from './create-customer-form-dialog.component';

describe('CreateCustomerFormDialogComponent', () => {
  let component: CreateCustomerFormDialogComponent;
  let fixture: ComponentFixture<CreateCustomerFormDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateCustomerFormDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateCustomerFormDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
