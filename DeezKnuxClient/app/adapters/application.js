
import DS from 'ember-data';
import ENV from 'deez-knux-client/config/environment'

export default DS.JSONAPIAdapter.extend({
  // Application specific overrides go here
    //namespace: ENV.App.namespace,
    host: ENV.APP.host
});