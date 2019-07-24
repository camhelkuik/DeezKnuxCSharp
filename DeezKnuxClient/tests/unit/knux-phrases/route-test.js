import { module, test } from 'qunit';
import { setupTest } from 'ember-qunit';

module('Unit | Route | knux-phrases', function(hooks) {
  setupTest(hooks);

  test('it exists', function(assert) {
    let route = this.owner.lookup('route:knux-phrases');
    assert.ok(route);
  });
});
