import { AuthorizationService } from "@shared/services/authorization-service/authorization.service";

export const appInitializer = (authorizationService: AuthorizationService) => () => new Promise((resolve) => {
  // attempt to refresh token on app start up to auto authenticate
  authorizationService.refreshToken()
    .subscribe()
    .add(resolve);
});
