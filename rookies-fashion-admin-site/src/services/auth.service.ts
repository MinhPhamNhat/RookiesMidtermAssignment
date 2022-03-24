import { UserManager, User } from "oidc-client";
import { storeUser, storeUserError } from "../actions";
import config from "../indentity/config";

// const userManager = new UserManager(config);

class AuthService {
  public userManager: UserManager;

  constructor() {
    this.userManager = new UserManager(config);
  }

  public getUserAsync(): Promise<User | null> {
    return this.userManager.getUser();
  }

  public loginAsync(): Promise<void> {
    console.log(this)
    return this.userManager.signinRedirect({
      state: window.location.hash,
    });
  }

  public completeLoginAsync(url: string): Promise<User | undefined> {
    return this.userManager.signinRedirectCallback(url);
  }

  public renewTokenAsync(): Promise<User> {
    return this.userManager.signinSilent();
  }

  public logoutAsync(): Promise<void> {
    this.userManager.clearStaleState();
    this.userManager.removeUser();
    return this.userManager.signoutRedirect();
  }

  public async completeLogoutAsync(url: string): Promise<void> {
    await this.userManager.signoutRedirectCallback(url);
  }

  public async loadUserFromStorage(store: any) {
    try {
      let user = await this.userManager.getUser();
      console.log(user);
      if (!user) {
        return store.dispatch(storeUserError());
      }
      store.dispatch(storeUser(user));
    } catch (e) {
      console.log(`User not found: ${e}`);
      return store.dispatch(storeUserError());
    }
  }
  
}

export default new AuthService();

// export function signinRedirect() {
//   return userManager.signinRedirect();
// }

// export function signinRedirectCallback() {
//   return userManager.signinRedirectCallback();
// }

// export function signoutRedirect() {
//   userManager.clearStaleState();
//   userManager.removeUser();
//   return userManager.signoutRedirect();
// }

// export function signoutRedirectCallback() {
//   userManager.clearStaleState();
//   userManager.removeUser();
//   return userManager.signoutRedirectCallback();
// }

// export default userManager;
