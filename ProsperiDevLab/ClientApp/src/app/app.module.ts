import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule, MatRippleModule, MAT_DATE_FORMATS } from '@angular/material/core';

import { CreateServiceOrderFormComponentDialog } from './components/ServiceOrder/create-service-order-form-dialog/create-service-order-form-dialog.component';
import { ServiceOrderListComponent } from './components/ServiceOrder/service-order-list/service-order-list.component';
import { DeleteServiceOrderDialogComponent } from './components/ServiceOrder/delete-service-order-form-dialog/delete-service-order-form-dialog.component';
import { PROSPERI_DATE_FORMATS } from './configs/prosperi-date-format.config';

@NgModule({
  declarations: [
    AppComponent,
    ServiceOrderListComponent,
    CreateServiceOrderFormComponentDialog,
    DeleteServiceOrderDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    MatIconModule,
    MatMenuModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDialogModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatRippleModule
  ],
  providers: [
    { provide: MAT_DATE_FORMATS, useValue: PROSPERI_DATE_FORMATS }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
