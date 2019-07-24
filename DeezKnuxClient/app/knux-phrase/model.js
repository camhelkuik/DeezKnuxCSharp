import DS from 'ember-data';

const { attr, belongsTo } = DS;

export default DS.Model.extend({
    knuxValue: attr('string'),
    owner: belongsTo('person')
});
