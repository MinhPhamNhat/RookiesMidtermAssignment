import { UserManagerSettings } from "oidc-client";

const config : UserManagerSettings = {
    authority: process.env.REACT_APP_API_URL,
    client_id: "admin",
    redirect_uri: `${process.env.REACT_APP_PUBLIC_URL}/authentication/login-callback`,
    post_logout_redirect_uri: `${process.env.REACT_APP_PUBLIC_URL}/authentication/logout-callback`,
    response_type: "id_token token",
    scope: "rookiesfashion.api openid profile offline_access",
    automaticSilentRenew: true,
    includeIdTokenInSilentRenew: true,
    loadUserInfo: true
};
export default config;
