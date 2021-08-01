const assert = require('chai').assert;
const lookupChar = require('../03. Char-Lookup');

describe('test char lookup', () => {
    it('should return undefined', () => {
        assert.equal(lookupChar(1, 2), undefined);
        assert.equal(lookupChar('dasdas', '1'), undefined);
        assert.equal(lookupChar(1, '1'), undefined);
        assert.equal(lookupChar('asdf', 1.5), undefined);
    })

    it('should return incorect number', () => {
        assert.equal(lookupChar('asdf', -1),'Incorrect index');
        assert.equal(lookupChar('asdf', 4),'Incorrect index')
    })

    it('should return f', () => {
        assert.equal(lookupChar('asfdr', 2), 'f');
    })
})