import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';

import { IconsProviderModule } from '../icons-provider.module';

import { ButtonsModule } from '@progress/kendo-angular-buttons';
import { DialogsModule } from '@progress/kendo-angular-dialog';
import { GridModule } from '@progress/kendo-angular-grid';
import { IconsModule } from '@progress/kendo-angular-icons';
import { IndicatorsModule } from '@progress/kendo-angular-indicators';
import { FormFieldModule, InputsModule, TextAreaModule, TextBoxModule } from '@progress/kendo-angular-inputs';
import { LabelModule } from '@progress/kendo-angular-label';
import { LayoutModule } from '@progress/kendo-angular-layout';
import { NavigationModule } from '@progress/kendo-angular-navigation';

import { LoginComponent } from './components/login/login.component';

const externalLibs = [
  CommonModule,
  FontAwesomeModule,
  FormsModule,
  ReactiveFormsModule,

  NzLayoutModule,
  NzMenuModule,
  NzBreadCrumbModule,

  IconsProviderModule,

  ButtonsModule,
  DialogsModule,
  FormFieldModule,
  GridModule,
  IconsModule,
  InputsModule,
  IndicatorsModule,
  LabelModule,
  LayoutModule,
  NavigationModule,
  TextAreaModule,
  TextBoxModule,
];

const components = [
  LoginComponent
];

@NgModule({
  declarations: [
    ...components
  ],
  imports: [
    ...externalLibs
  ],
  exports: [
    ...externalLibs,
    ...components,
  ]
})
export class SharedModule { }
