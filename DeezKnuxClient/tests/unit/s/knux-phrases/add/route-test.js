import { module, test } from 'qunit';
import { setupTest } from 'ember-qunit';

module('Unit | Route | s/knux-phrases/add', function(hooks) {
  setupTest(hooks);

  test('it exists', function(assert) {
    let route = this.owner.lookup('route:s/knux-phrases/add');
    assert.ok(route);
  });
});
