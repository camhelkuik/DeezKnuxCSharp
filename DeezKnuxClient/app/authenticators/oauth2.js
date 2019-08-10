import OAuth2PasswordGrant from 'ember-simple-auth/authenticators/oauth2-password-grant';
import ENV from 'deez-knux-client/config/environment';

export default OAuth2PasswordGrant.extend({
    serverTokenEndpoint: `${ENV.APP.host}/${ENV.APP.tokenPath}`
});