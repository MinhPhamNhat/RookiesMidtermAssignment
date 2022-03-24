import React, { useEffect, useRef } from "react";
import { UserManager } from "oidc-client";

import { storeUser } from "../../actions";
import AuthService from "../../services/auth.service";
import { setAuthHeader } from "../../utils/HttpClient/base";
import { loginRedirect, loginRedirectCalback } from "../../actions";
export default function AuthProvider({ store, children }: any) {
  useEffect(() => {
    // fetch current user from cookies
    store.dispatch(loginRedirect);
    store.dispatch(loginRedirectCalback);
  }, []);
  console.log();

  //   let userManager = useRef<UserManager>();

  //   useEffect(() => {
  //     userManager.current = manager;

  //     const onUserLoaded = (user: any) => {
  //       console.log(`user loaded: ${user}`);
  //       store.dispatch(storeUser(user));
  //     };

  //     const onUserUnloaded = () => {
  //       setAuthHeader(null);
  //       console.log(`user unloaded`);
  //     };

  //     const onAccessTokenExpiring = () => {
  //       console.log(`user token expiring`);
  //     };

  //     const onAccessTokenExpired = () => {
  //       console.log(`user token expired`);
  //     };

  //     const onUserSignedOut = () => {
  //       console.log(`user signed out`);
  //     };

  //     // events for user
  //     userManager?.current?.events.addUserLoaded(onUserLoaded);
  //     userManager?.current?.events.addUserUnloaded(onUserUnloaded);
  //     userManager?.current?.events.addAccessTokenExpiring(onAccessTokenExpiring);
  //     userManager?.current?.events.addAccessTokenExpired(onAccessTokenExpired);
  //     userManager?.current?.events.addUserSignedOut(onUserSignedOut);

  //     // Specify how to clean up after this effect:
  //     return function cleanup() {
  //       userManager?.current?.events.removeUserLoaded(onUserLoaded);
  //       userManager?.current?.events.removeUserUnloaded(onUserUnloaded);
  //       userManager?.current?.events.removeAccessTokenExpiring(
  //         onAccessTokenExpiring
  //       );
  //       userManager?.current?.events.removeAccessTokenExpired(
  //         onAccessTokenExpired
  //       );
  //       userManager?.current?.events.removeUserSignedOut(onUserSignedOut);
  //     };
  //   }, [manager, store]);

  return React.Children.only(children);
}
