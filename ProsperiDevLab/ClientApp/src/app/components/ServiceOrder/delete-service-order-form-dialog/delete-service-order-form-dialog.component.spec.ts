import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteServiceOrderDialogComponent } from './delete-service-order-form-dialog.component';

describe('DeleteServiceOrderDialogComponent', () => {
  let component: DeleteServiceOrderDialogComponent;
  let fixture: ComponentFixture<DeleteServiceOrderDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteServiceOrderDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteServiceOrderDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
