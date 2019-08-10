
import DS from 'ember-data';
import ENV from 'deez-knux-client/config/environment'
import { computed }  from '@ember/object';

import { inject as service } from '@ember/service';

export default DS.JSONAPIAdapter.extend({
  session: service(),
  // Application specific overrides go here
    //namespace: ENV.App.namespace,
    host: ENV.APP.host, 

    headers: computed('session.data.authenticated.token', function() {
      let token = this.get('session.data.authenticated.access_token');
      return { Authorization: `Bearer ${token}`};
    })
});