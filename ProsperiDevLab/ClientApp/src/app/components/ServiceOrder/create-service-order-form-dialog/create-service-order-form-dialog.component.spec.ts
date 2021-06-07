import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateServiceOrderFormComponent } from './create-service-order-form-dialog.component';

describe('CreateServiceOrderFormComponent', () => {
  let component: CreateServiceOrderFormComponent;
  let fixture: ComponentFixture<CreateServiceOrderFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateServiceOrderFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateServiceOrderFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
