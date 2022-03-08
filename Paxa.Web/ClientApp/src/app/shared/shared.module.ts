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
import { NzResultModule } from 'ng-zorro-antd/result';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzTabsModule } from 'ng-zorro-antd/tabs';
import { NzTimePickerModule } from 'ng-zorro-antd/time-picker';

import { IconsProviderModule } from '../icons-provider.module';
import { RouterModule } from '@angular/router';

const externalLibs = [
  CommonModule,
  FormsModule,
  ReactiveFormsModule,
  RouterModule,

  NzBreadCrumbModule,
  NzButtonModule,
  NzFormModule,
  NzIconModule,
  NzInputModule,
  NzLayoutModule,
  NzMenuModule,
  NzModalModule,
  NzPageHeaderModule,
  NzResultModule,
  NzSelectModule,
  NzTableModule,
  NzTabsModule,
  NzTimePickerModule,

  IconsProviderModule,
];

const components = [

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
