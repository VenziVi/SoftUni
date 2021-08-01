const assert = require('chai').assert;
const isOddOrEven = require('../02. Even-or-Odds');

describe('test Even or Odds function', () => {
    it('should return undefined', () => {
        
        assert.equal(isOddOrEven(1), undefined);
        assert.equal(isOddOrEven([]), undefined);
        assert.equal(isOddOrEven(NaN), undefined);
    })

    it('should return even', () => {
        assert.equal(isOddOrEven('asdf'), 'even');
    })

    it('should return odd', () => {
        assert.equal(isOddOrEven('asddf'), 'odd');
    })
})