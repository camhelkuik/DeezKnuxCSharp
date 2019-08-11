import Route from '@ember/routing/route';

export default Route.extend( {
    model() {
        return this.store.createRecord('knux-phrase');
    },

    actions: {
        submitAction(){
            this.get('controller.model')
            .save()
            .then(() => {
                this.transitionTo('s.knux-phrases');
            });
        }
    }
});
