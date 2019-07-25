import DS from 'ember-data';

const { attr, belongsTo } = DS;

export default DS.Model.extend({
    knuxvalue: attr('string'),
    owner: belongsTo('person')
});
