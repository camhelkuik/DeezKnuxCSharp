import Route from '@ember/routing/route';
import ApplicationRouteMixin from 'ember-simple-auth/mixins/application-route-mixin';

export default Route.extend(ApplicationRouteMixin, {
    sessionAuthenticated() {
        //call the base method?
        this._super(...arguments);
        this.transitionTo('s.knux-phrases');
    }
});
