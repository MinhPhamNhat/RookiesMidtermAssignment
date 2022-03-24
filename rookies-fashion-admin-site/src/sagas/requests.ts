import { AxiosResponse } from "axios";
import { User } from "oidc-client";

import AuthService from '../services/auth.service';

export function loginRequest(): Promise<void> {
    return AuthService.loginAsync();
}

export function loginCallbackRequest(): Promise<User | undefined> {
    return AuthService.completeLoginAsync(window.location.href);
}

export function getMeRequest(): Promise<User | null> {
    return AuthService.getUserAsync();
}

export function logoutRequest(): Promise<void> {
    return AuthService.logoutAsync();
}

export function logoutCallbackRequest(): Promise<void> {
    return AuthService.completeLogoutAsync(window.location.href);
}


