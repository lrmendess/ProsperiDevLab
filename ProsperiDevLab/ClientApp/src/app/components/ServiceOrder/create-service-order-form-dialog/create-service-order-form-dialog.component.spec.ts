import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateServiceOrderFormDialogComponent } from './create-service-order-form-dialog.component';

describe('CreateServiceOrderFormComponent', () => {
  let component: CreateServiceOrderFormDialogComponent;
  let fixture: ComponentFixture<CreateServiceOrderFormDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateServiceOrderFormDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateServiceOrderFormDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
