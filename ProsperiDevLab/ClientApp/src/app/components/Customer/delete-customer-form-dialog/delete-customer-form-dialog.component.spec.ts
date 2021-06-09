import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteCustomerFormDialogComponent } from './delete-customer-form-dialog.component';

describe('DeleteCustomerFormDialogComponent', () => {
  let component: DeleteCustomerFormDialogComponent;
  let fixture: ComponentFixture<DeleteCustomerFormDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteCustomerFormDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteCustomerFormDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
