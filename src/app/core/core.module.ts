import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { environment } from 'src/environments/environment';

import { BookingProxy } from './booking/booking.proxy.base';
import { BookingProxyApi } from './booking/booking.proxy.api';
import { BookingProxyMock } from './booking/booking.proxy.mock';

import { UserProxy } from './user/user.proxy.base';
import { UserProxyApi } from './user/user.proxy.api';
import { UserProxyMock } from './user/user.proxy.mock';

import { FacilityProxy } from './facility/facility.proxy.base';
import { FacilityProxyApi } from './facility/facility.proxy.api';
import { FacilityProxyMock } from './facility/facility.proxy.mock';

import { PersonProxy } from './person/person.proxy.base';
import { PersonProxyApi } from './person/person.proxy.api';
import { PersonProxyMock } from './person/person.proxy.mock';

import { ResourceProxy } from './resource/resource.proxy.base';
import { ResourceProxyApi } from './resource/resource.proxy.api';
import { ResourceProxyMock } from './resource/resource.proxy.mock';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    {
      provide: BookingProxy,
      useClass: environment.production
        ? BookingProxyApi
        : BookingProxyMock
    },
    {
      provide: FacilityProxy,
      useClass: environment.production
        ? FacilityProxyApi
        : FacilityProxyMock
    },
    {
      provide: PersonProxy,
      useClass: environment.production
        ? PersonProxyApi
        : PersonProxyMock
     },
    {
      provide: ResourceProxy,
      useClass: environment.production
        ? ResourceProxyApi
        : ResourceProxyMock
    },
    {
      provide: UserProxy,
      useClass: environment.production
        ? UserProxyApi
        : UserProxyMock
    },
  ]
})
export class CoreModule { }
