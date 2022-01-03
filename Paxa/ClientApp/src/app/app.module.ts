import { BrowserModule } from '@angular/platform-browser';
import { APP_INITIALIZER, NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { registerLocaleData } from '@angular/common';
import sv from '@angular/common/locales/sv';

import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { sv_SE } from 'ng-zorro-antd/i18n';

import { appInitializer } from './app-initializer';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { SharedModule } from '@shared/shared.module';
import { UserService } from '@user/services/user.service';

import { BearerTokenInterceptor } from '@core/bearer-token/bearer-token.interceptor';
import { HttpsStatusInterceptor } from '@core/http-status/https-status.interceptor';

import { GetStartedComponent } from './get-started/get-started.component';
import { LogoutComponent } from './logout/logout.component';
import { LoginComponent } from './login/login.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { NotAllowedComponent } from './not-allowed/not-allowed.component';
import { WelcomeComponent } from './welcome/welcome.component';

registerLocaleData(sv);

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    LogoutComponent,
    LoginComponent,
    GetStartedComponent,
    NotFoundComponent,
    NotAllowedComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    AppRoutingModule,
    SharedModule,
    BrowserAnimationsModule,
  ],
  providers: [
    { provide: APP_INITIALIZER, useFactory: appInitializer, multi: true, deps: [UserService] },
    { provide: HTTP_INTERCEPTORS, useClass: HttpsStatusInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: BearerTokenInterceptor, multi: true },
    { provide: NZ_I18N, useValue: sv_SE }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
