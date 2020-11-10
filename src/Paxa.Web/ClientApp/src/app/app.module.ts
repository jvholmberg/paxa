import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatFormFieldModule } from '@angular/material/form-field';
import { GoogleMapsModule } from '@angular/google-maps';

import { CoreModule } from '@core/core.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';

import { DashboardComponent } from './dashboard/dashboard.component';
import { LandingComponent } from './landing/landing.component';
import { GetStartedComponent } from './get-started/get-started.component';
import { NotAllowedComponent } from './not-allowed/not-allowed.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { SettingsComponent } from './settings/settings.component';
import { PaymentComponent } from './settings/payment/payment.component';
import { UserComponent } from './settings/user/user.component';
import { FacilityComponent } from './facility/facility.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    LandingComponent,
    GetStartedComponent,
    NavbarComponent,
    NotAllowedComponent,
    NotFoundComponent,
    FooterComponent,
    SettingsComponent,
    PaymentComponent,
    UserComponent,
    FacilityComponent,
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    CommonModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    MatToolbarModule,
    MatCardModule,
    MatListModule,
    MatGridListModule,
    MatFormFieldModule,
    GoogleMapsModule,
    CoreModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
