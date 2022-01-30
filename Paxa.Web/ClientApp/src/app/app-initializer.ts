import { UserService } from "@user/services/user.service";

export const appInitializer = (userService: UserService) => () => new Promise((resolve) => {
  // attempt to refresh token on app start up to auto authenticate
  userService.refreshToken()
    .subscribe()
    .add(resolve);
});
