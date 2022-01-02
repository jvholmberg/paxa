import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NzBreadCrumbModule } from 'ng-zorro-antd/breadcrumb';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzInputModule } from 'ng-zorro-antd/input';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzPageHeaderModule } from 'ng-zorro-antd/page-header';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzTableModule } from 'ng-zorro-antd/table';

import { IconsProviderModule } from '../icons-provider.module';

import { LoginComponent } from './components/login/login.component';

const externalLibs = [
  CommonModule,
  FormsModule,
  ReactiveFormsModule,

  NzBreadCrumbModule,
  NzButtonModule,
  NzFormModule,
  NzIconModule,
  NzInputModule,
  NzLayoutModule,
  NzMenuModule,
  NzModalModule,
  NzPageHeaderModule,
  NzSelectModule,
  NzTableModule,

  IconsProviderModule,
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
